using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using MpcApi;
using System.IO;
using System.Text.RegularExpressions;

namespace ClassicSub
{
    public partial class ClassicSubForm : MPCControlForm
    {
        // Win32 Imports
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32.dll", CharSet=CharSet.Auto, SetLastError=true)]
        public static extern int GetWindowThreadProcessId(int handle, out int processId);

        // Members
        private BindingList<Subtitle> subList = new BindingList<Subtitle>();
        string[] SubtitleFileName = new string[5]; // note: element zero is always empty, sorry about that...
        int CurrentlyHighlightedRow = -1;
        bool CurrentlyHighlightFullyLit = false;
        public Overlay overlay = null;
        public bool Text2Enabled = false;
        public bool Text3Enabled = false;
        public bool Text4Enabled = false;

        System.Windows.Forms.Timer UpdateUITimer = new System.Windows.Forms.Timer();

        public ChineseDictionary chineseDict = null;

        public ClassicSubForm(string[] args)
        {
            SubtitleFileName[1] = "";
            SubtitleFileName[2] = "";
            SubtitleFileName[3] = "";
            SubtitleFileName[4] = "";

            InitializeComponent();

            UpdateUITimer.Tick += new EventHandler(UpdateUITimer_Tick);
            UpdateUITimer.Interval = 50;
            UpdateUITimer.Start();

            Subtitle sub1 = new Subtitle()
            {
                Number = 1,
                Start = "00:00:01.000",
                End = "00:00:05.000",
                Duration = "4.000",
                SubText1 = "Subtitles Go Here"
            };

            Subtitle sub2 = new Subtitle()
            {
                Number = 2,
                Start = "00:00:06.000",
                End = "00:00:08.500",
                Duration = "2.500",
                SubText1 = "And Here"
            };

            subList.Add(sub1);
            subList.Add(sub2);

            dataGridView.DataSource = subList;
            UpdateUI();
            DoRenumber();

            if (args.Length >= 1)
            {
                DoOpenFile(args[0]);
            }
        }

        void UpdateUITimer_Tick(object sender, EventArgs e)
        {
            if (VideoCurrentlyOpen && subList.Count > 0)
            {
                UpdateUITime();
                UpdateNextNewSubtitle();

                bool fullyLit = false;
                int index = GetRowToHighlight(ref fullyLit);

                if (autoFollowCheckBox.Checked && !dataGridView.IsCurrentCellInEditMode)
                {
                    scrollGridEnsureOnScreen(index);
                }

                // Check if the row should be highlighted
                int displayedRowCount = dataGridView.DisplayedRowCount(true);

                if (index != CurrentlyHighlightedRow
                    || fullyLit != CurrentlyHighlightFullyLit)
                {
                    if (overlay != null)
                    {
                        string text = GetCurrentTimeSubText();

                        if (text != overlay.SubTitleText)
                        {
                            overlay.SetSubtitle(text);
                        }
                    }

                    bool refresh = false;

                    if ((index >= dataGridView.FirstDisplayedScrollingRowIndex
                            && index <= dataGridView.FirstDisplayedScrollingRowIndex + displayedRowCount - 1)
                        || (CurrentlyHighlightedRow >= dataGridView.FirstDisplayedScrollingRowIndex
                            && CurrentlyHighlightedRow <= dataGridView.FirstDisplayedScrollingRowIndex + displayedRowCount - 1))
                    {
                        // We should refresh, because either the current or the previously highlighted row is on screen
                        refresh = true;
                    }

                    CurrentlyHighlightedRow = index;
                    CurrentlyHighlightFullyLit = fullyLit;

                    if (refresh)
                    {
                        dataGridView.Refresh();
                    }
                }
            }
            else
            {
                if (overlay != null)
                {
                    int curPos = GetCurrentCellIndex();
                    if (curPos > -1)
                    {
                        string text = GetOverlaySubtitleText(subList[curPos]);

                        if (text != overlay.SubTitleText)
                        {
                            overlay.SetSubtitle(text);
                        }
                    }
                }
            }

            if (overlay != null && !ThisAppHasFocus())
            {
                overlay.BringToFront();
            }
        }

        bool ThisAppHasFocus()
        {
            int testWnd = GetForegroundWindow().ToInt32();

            if (testWnd != 0)
            {
                int processIdThis = 0;
                int processIdTest = 0;
                GetWindowThreadProcessId(testWnd, out processIdTest);
                GetWindowThreadProcessId(this.Handle.ToInt32(), out processIdThis);

                if (processIdThis != 0 && processIdTest != 0)
                {
                    return (processIdThis == processIdTest);
                }
            }
            return false;
        }

        void UpdateUI()
        {
            string filename = "(No subtitle file)";
            if (SubtitleFileName[1].Length > 0)
            {
                filename = System.IO.Path.GetFileName(SubtitleFileName[1]);
            }
            this.Text = filename + " - ClassicSub - v0.0.0.1";

            filename = "No video file";
            if (VideoFileName.Length > 0)
            {
                if (VideoFileName.Length > 40)
                {
                    filename = VideoFileName.Substring(0, 20) + "..." + VideoFileName.Substring(VideoFileName.Length-20, 20);
                }
                else
                {
                    filename = VideoFileName;
                }
            }
            videoFiletoolStripStatusLabel.Text = filename;

            UpdateUITime();

            dataGridView.Refresh();
        }

        void UpdateUITime()
        {
            int temp = CurrentPositionMs;
            int hours = temp / (60 * 60 * 1000);
            temp -= hours * (60 * 60 * 1000);
            int mins = temp / (60 * 1000);
            temp -= mins * (60 * 1000);
            double floatSecs = ((double)temp) / 1000;

            temp = VideoDurationMs;
            int totalHours = temp / (60 * 60 * 1000);
            temp -= totalHours * (60 * 60 * 1000);
            int totalMins = temp / (60 * 1000);
            temp -= totalMins * (60 * 1000);
            int totalSecs = temp / 1000;
            
            string formatted;

            if (VideoCurrentlyPlaying)
            {
                formatted = String.Format(" {0}:{1:00}:{2:00.0}     / {3}:{4:00}:{5:00}", hours, mins, floatSecs, totalHours, totalMins, totalSecs);
            }
            else
            {
                formatted = String.Format(" {0}:{1:00}:{2:00.000} / {3}:{4:00}:{5:00}", hours, mins, floatSecs, totalHours, totalMins, totalSecs);
            }

            toolStripTextBoxCurrentTime.Text = formatted;
        }

        void UpdateNextNewSubtitle()
        {
            Subtitle.NextNewSubtitleNumber = subList.Count + 1;

            if (subList.Count > 0)
            {
                int start = subList[subList.Count - 1].StartMs;
                int end = subList[subList.Count - 1].EndMs;
                int currTime = CurrentPositionMs;
                Subtitle.NextNewSubtitleStartMs = Math.Max(Math.Max(start, end), currTime);
            }
            else
            {
                Subtitle.NextNewSubtitleStartMs = 0;
            }
        }

        public bool DoProcessCmdKey(ref Message msg, Keys keyData)
        {
            msg.HWnd = this.Handle;
            return ProcessCmdKey(ref msg, keyData);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // override DataGrid's Control H (deletes current cell)
            if (keyData == (Keys.Control | Keys.H))
            {
                return true; //we handled the key
            }

            if (!dataGridView.IsCurrentCellInEditMode)
            {
                if (keyData == Keys.Space)
                {
                    SendPlayPause();
                    return true;
                }
                else if (keyData == Keys.OemBackslash)
                {
                    DoInsert();
                    return true;
                }
                else if (keyData == Keys.OemOpenBrackets)
                {
                    DoSetCurrentStart();
                    return true;
                }
                else if (keyData == Keys.OemCloseBrackets)
                {
                    DoSetCurrentEnd();
                    return true;
                }
            }

            // Ctrl+E and Ctrl+. had a few problems, override here
            /*if (keyData == (Keys.Control | Keys.E))
            {
                DoEditCurrent();
                return true; //we handled the key
            }
            else*/ if (keyData == (Keys.Control | Keys.OemPeriod))
            {
                SendJump(1);
                return true; //we handled the key
            }

            return base.ProcessCmdKey(ref msg, keyData); //we didn't handle it
        }

        void DoOpenFile(string fileName)
        {
            Cursor.Current = Cursors.WaitCursor;

            BindingList<Subtitle> subListTemp = Subtitle.ReadSubtitleFile(fileName);

            if (subListTemp != null)
            {
                SubtitleFileName[1] = fileName;
                subList = subListTemp;
                dataGridView.DataSource = subList;
                UpdateUI();
                DoRenumber();

                dataGridView.Columns["SubText2"].Visible = false;
                dataGridView.Columns["SubText3"].Visible = false;
                dataGridView.Columns["SubText4"].Visible = false;

                Text2Enabled = false;
                Text3Enabled = false;
                Text4Enabled = false;        
            }
        }

        void DoAppendFile(string fileName, int offset)
        {
            BindingList<Subtitle> subListTemp = Subtitle.ReadSubtitleFile(fileName);

            if (subListTemp != null)
            {
                foreach (Subtitle sub in subListTemp)
                {
                    sub.StartMs += offset;
                    sub.EndMs += offset;
                    subList.Add(sub);
                }
                UpdateUI();
                DoRenumber();
            }
        }

        void DoSaveFile(int textNum)
        {
            if (SubtitleFileName[textNum].Length > 0)
            {
                WriteFile(SubtitleFileName[textNum], textNum);
            }
            else
            {
                DoSaveAs(textNum);
            }
        }

        protected void WriteFile(string fileName, int textIndex)
        {
            Cursor.Current = Cursors.WaitCursor;

            FileInfo fi = new FileInfo(fileName);
            using (FileStream fs = fi.Create())
            {
                using (StreamWriter writer = new StreamWriter(fs, new UTF8Encoding(true)))
                {
                    foreach (Subtitle sub in subList)
                    {
                        string timeLine = String.Format("{0} --> {1}", sub.GetStartForSRT(), sub.GetEndForSRT());

                        writer.WriteLine(sub.Number);
                        writer.WriteLine(timeLine);
                        writer.WriteLine(sub.GetSubText(textIndex));
                        writer.WriteLine();
                    }
                }
            }
        }

        protected void DoSaveAs(int textNum)
        {
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                if (saveFileDialog.FileName.Length > 0)
                {
                    SubtitleFileName[textNum] = saveFileDialog.FileName;
                    DoSaveFile(textNum);
                    UpdateUI();
                }
            }
        }

        private void DoSeek()
        {
            if (VideoCurrentlyOpen)
            {
                using (SeekForm seek = new SeekForm(CurrentPositionMs))
                {
                    seek.ShowDialog(this);

                    if (seek.okClicked)
                    {
                        SendSetPosition(seek.GetSeekTime() / 1000);
                    }
                }
            }
            else
            {
                MessageBox.Show("Media Player Classic must have an open video to seek.");
            }
        }

        int GetCurrentTimeIndex()
        {
            int idx = -1;
            int curIndex = 0;
            int curPos = CurrentPositionMs;

            foreach (Subtitle subObj in subList)
            {
                // return the index of the latest subtitle that starts before the current time
                if (subObj.StartMs <= curPos)
                {
                    idx = curIndex;
                }
                curIndex++;
            }

            return idx;
        }

        string GetCurrentTimeSubText()
        {
            string subText = "";
            int curPos = CurrentPositionMs;

            foreach (Subtitle subObj in subList)
            {
                // return the index of the latest subtitle that starts before the current time
                if (subObj.StartMs <= curPos && subObj.EndMs >= curPos)
                {
                    subText = GetOverlaySubtitleText(subObj);
                }
            }

            return subText;
        }

        string GetOverlaySubtitleText(Subtitle subObj)
        {
            string subText = subObj.SubText1;

            if (Text2Enabled && subObj.SubText2.Length > 0)
            {
                subText += "\n";
                subText += subObj.SubText2;
            }

            if (Text3Enabled && subObj.SubText3.Length > 0)
            {
                subText += "\n";
                subText += subObj.SubText3;
            }

            if (Text4Enabled && subObj.SubText4.Length > 0)
            {
                subText += "\n";
                subText += subObj.SubText4;
            }

            return subText;
        }

        int GetRowToHighlight(ref bool fullyLit)
        {
            int idx = 0;
            int curIndex = 0;
            int curPos = CurrentPositionMs;

            foreach (Subtitle subObj in subList)
            {
                if (subObj.StartMs <= curPos)
                {
                    if (subObj.EndMs >= curPos)
                    {
                        idx = curIndex;
                        fullyLit = true;
                    }
                    else
                    {
                        idx = curIndex + 1;
                        fullyLit = false;
                    }
                }
                curIndex++;
            }

            return idx;
        }

        int GetCurrentCellIndex()
        {
            int foundIdx = -1;

            if (dataGridView.CurrentCell != null)
            {
                int idx = dataGridView.CurrentCell.RowIndex;

                if (idx < subList.Count)
                {
                    foundIdx = idx;
                }
            }

            return foundIdx;
        }

        int GetCurrentCellStart()
        {
            int idx = -1;
            
            if (dataGridView.CurrentCell != null)
            {

                idx = dataGridView.CurrentCell.RowIndex;

                if (idx < subList.Count)
                {
                    return subList[idx].StartMs;
                }
            }

            return idx;
        }

        int GetCurrentCellEnd()
        {
            int idx = -1;

            if (dataGridView.CurrentCell != null)
            {
                idx = dataGridView.CurrentCell.RowIndex;

                if (idx < subList.Count)
                {
                    return subList[idx].EndMs;
                }
            }

            return idx;
        }

        int GetNextCellStart()
        {
            int idx = -1;
            
            if (dataGridView.CurrentCell != null)
            {
                idx = dataGridView.CurrentCell.RowIndex;

                if ((idx + 1) < subList.Count)
                {
                    return subList[idx + 1].StartMs;
                }
            }

            return idx;
        }

        int GetNextCellEnd()
        {
            int idx = -1;
            
            if (dataGridView.CurrentCell != null)
            {
                idx = dataGridView.CurrentCell.RowIndex;

                if ((idx + 1) < subList.Count)
                {
                    return subList[idx + 1].EndMs;
                }
            }

            return idx;
        }

        int GetPrevCellEnd()
        {
            int idx = -1;
            
            if (dataGridView.CurrentCell != null)
            {
                idx = dataGridView.CurrentCell.RowIndex;

                if (idx > 0)
                {
                    return subList[idx-1].EndMs;
                }
            }

            return idx;
        }

        int GetPrevCellStart()
        {
            int idx = -1;
            
            if (dataGridView.CurrentCell != null)
            {
                idx = dataGridView.CurrentCell.RowIndex;

                if (idx > 0)
                {
                    return subList[idx-1].StartMs;
                }
            }

            return idx;
        }

        int GetLastSubtitleEndTime()
        {
            int endTime = 0;

            if (subList.Count > 0)
            {
                endTime = subList[subList.Count - 1].EndMs;
            }

            return endTime;
        }

        // Keeps the given index between the first and last third of the screen
        private void scrollGridEnsureOnScreen(int index)
        {
            int minPos = dataGridView.FirstDisplayedScrollingRowIndex + dataGridView.DisplayedRowCount(false) / 4;
            int maxPos = dataGridView.FirstDisplayedScrollingRowIndex + (dataGridView.DisplayedRowCount(false) * 3) / 4;
            if (index < minPos || index >= maxPos)
            {
                int displayedRowCount = dataGridView.DisplayedRowCount(false);
                int newRow = index - displayedRowCount / 4;

                dataGridView.FirstDisplayedScrollingRowIndex = Math.Max(0, Math.Min(newRow, dataGridView.Rows.Count - 1));
            }
        }

        // Scrolss the grid to the selected cell
        private void scrollGridSelectedToMiddle()
        {
            if (dataGridView.SelectedCells != null)
            {
                int halfWay = (dataGridView.DisplayedRowCount(false) / 2);
                if (dataGridView.FirstDisplayedScrollingRowIndex + halfWay > dataGridView.SelectedCells[0].RowIndex ||
                    (dataGridView.FirstDisplayedScrollingRowIndex + dataGridView.DisplayedRowCount(false) - halfWay) <= dataGridView.SelectedCells[0].RowIndex)
                {
                    int targetRow = dataGridView.SelectedCells[0].RowIndex;
                    targetRow = Math.Max(targetRow - halfWay, 0);
                    dataGridView.FirstDisplayedScrollingRowIndex = targetRow;
                }
            }
        }

        void DoEditCurrent()
        {
            dataGridView.BeginEdit(false);
        }

        void DoInsert()
        {
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
            dataGridView.ClearSelection();
            int idx = GetCurrentTimeIndex() + 1;
            if (idx == dataGridView.Rows.Count)
            {
                idx = GetCurrentTimeIndex();
            }

            Subtitle sub = new Subtitle();
            sub.Number = dataGridView.Rows.Count;
            sub.StartMs = CurrentPositionMs;
            sub.EndMs = CurrentPositionMs;

            subList.Insert(idx, sub);

            DoRenumber();

            dataGridView.Rows[idx].Cells["SubText1"].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[idx].Cells["SubText1"];
        }

        void DoInsertBefore()
        {
            int idx = 0;

            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView.ClearSelection();

                idx = dataGridView.CurrentCell.RowIndex;
            }
                
            int nextCellStart = GetCurrentCellStart();

            if (nextCellStart == 0)
            {
                nextCellStart = GetCurrentCellEnd();
            }

            int prevCellEnd = GetPrevCellEnd();

            if (prevCellEnd == 0)
            {
                prevCellEnd = GetPrevCellStart();
            }

            int currTime = CurrentPositionMs;
            int newTime = 0;

            if (nextCellStart == -1 && prevCellEnd == -1)
            {
                newTime = currTime;
            }
            else if (nextCellStart == -1)
            {
                newTime = Math.Max(currTime, prevCellEnd);
            }
            else if (prevCellEnd == -1)
            {
                if (currTime < nextCellStart)
                {
                    newTime = currTime;
                }
                else
                {
                    newTime = 0;
                }
            }
            else
            {
                newTime = Math.Min(Math.Max(prevCellEnd, currTime), nextCellStart);
            }

            Subtitle sub = new Subtitle();
            sub.Number = dataGridView.Rows.Count;
            sub.StartMs = newTime;
            sub.EndMs = newTime;

            subList.Insert(idx, sub);

            DoRenumber();

            dataGridView.Rows[idx].Cells["SubText1"].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[idx].Cells["SubText1"];
        }

        void DoInsertAfter()
        {
            int idx = 0;

            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView.ClearSelection();

                idx = dataGridView.CurrentCell.RowIndex + 1;
                if (idx == dataGridView.Rows.Count)
                {
                    idx = dataGridView.CurrentCell.RowIndex;
                }
            }

            int nextCellStart = GetNextCellStart();

            if (nextCellStart == 0)
            {
                nextCellStart = GetNextCellEnd();
            }

            int prevCellEnd = GetCurrentCellEnd();

            if (prevCellEnd == 0)
            {
                prevCellEnd = GetCurrentCellStart();
            }

            int currTime = CurrentPositionMs;
            int newTime = 0;

            if (nextCellStart == -1 && prevCellEnd == -1)
            {
                newTime = currTime;
            }
            else if (nextCellStart == -1)
            {
                newTime = Math.Max(currTime, prevCellEnd);
            }
            else if (prevCellEnd == -1)
            {
                if (currTime < nextCellStart)
                {
                    newTime = currTime;
                }
                else
                {
                    newTime = 0;
                }
            }
            else
            {
                newTime = Math.Min(Math.Max(prevCellEnd, currTime), nextCellStart);
            }

            Subtitle sub = new Subtitle();
            sub.Number = dataGridView.Rows.Count;
            sub.StartMs = newTime;
            sub.EndMs = newTime;

            subList.Insert(idx, sub);

            DoRenumber();

            dataGridView.Rows[idx].Cells["SubText1"].Selected = true;
            dataGridView.CurrentCell = dataGridView.Rows[idx].Cells["SubText1"];
        }

        void DoDelete()
        {
            if (dataGridView.SelectedCells != null && subList.Count > 0)
            {
                if (MessageBox.Show("Delete all rows with selected cells?", "Confirm Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

                    SortedSet<int> set = new SortedSet<int>();

                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        if (cell.RowIndex < subList.Count)
                        {
                            set.Add(cell.RowIndex);
                        }
                    }

                    foreach (int rowIdx in set.Reverse())
                    {
                        subList.RemoveAt(rowIdx);
                    }
                }
            }
        }

        void DoNudgeTimes()
        {
            if (dataGridView.SelectedCells != null && subList.Count > 0)
            {
                using (NudgeForm nudge = new NudgeForm())
                {
                    nudge.ShowDialog(this);

                    if (nudge.okClicked)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        int nudgeTime = nudge.GetNudge();
                        
                        foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                        {
                            if (cell.RowIndex < subList.Count)
                            {
                                if (cell.OwningColumn.DataPropertyName == "Start")
                                {
                                    subList[cell.RowIndex].StartMs = Math.Max(subList[cell.RowIndex].StartMs + nudgeTime, 0);
                                    DoAutoDuration(cell.RowIndex);
                                    DoAutoDuration(cell.RowIndex - 1);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "End")
                                {
                                    subList[cell.RowIndex].EndMs = Math.Max(subList[cell.RowIndex].EndMs + nudgeTime, 0);
                                }
                            }
                        }
                    }
                }
            }
        }

        void DoSetCurrentStart()
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView.ClearSelection();

                int idx = dataGridView.CurrentCell.RowIndex;

                if (idx < subList.Count)
                {
                    subList[idx].StartMs = CurrentPositionMs;

                    dataGridView.Rows[idx].Cells["Start"].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[idx].Cells["Start"];

                    DoAutoDuration(idx);
                    DoAutoDuration(idx-1);
                }
            }
        }

        void DoSetCurrentEnd()
        {
            if (dataGridView.CurrentCell != null)
            {
                dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                dataGridView.ClearSelection();

                int idx = dataGridView.CurrentCell.RowIndex;

                if (idx < subList.Count)
                {
                    subList[idx].EndMs = CurrentPositionMs;

                    dataGridView.Rows[idx].Cells["End"].Selected = true;
                    dataGridView.CurrentCell = dataGridView.Rows[idx].Cells["End"];
                }
            }
        }

        void DoDuration(DurationRange range, DurationUpdate update, DurationCalculation calculation)
        {
            dataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);

            if (range == DurationRange.Selected)
            {
                if (dataGridView.SelectedCells != null && subList.Count > 0)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        UpdateDuration(cell.RowIndex, update, calculation);
                    }
                }
            }
            else
            {
                for (int i=0; i<subList.Count; i++)
                {
                    UpdateDuration(i, update, calculation);
                }
            }
        }

        void DoAutoDuration(int index)
        {
            if (ConfigForm.GetAutoDuration())
            {
                UpdateDuration(index, DurationUpdate.SetToCalculated, DurationCalculation.Algorithm);
            }
        }

        void UpdateDuration(int index, DurationUpdate update, DurationCalculation calculation)
        {
            int constant = ConfigForm.GetDurationConstant();
            int variable = ConfigForm.GetDurationVariable();
            int minimum = ConfigForm.GetDurationMinimum();

            if (index >= 0 && index < subList.Count)
            {
                Subtitle sub = subList[index];

                int duration;

                if (calculation == DurationCalculation.Algorithm)
                {
                    duration = constant + (sub.SubText1.Count() + sub.SubText2.Count() + sub.SubText3.Count() + sub.SubText4.Count()) * variable;

                    // enforce minimum
                    duration = Math.Max(minimum, duration);
                }
                else
                {
                    duration = (sub.DurationMs * DurationForm.GetDurationScale()) / 1000;
                }

                // ensure no overlap
                if ((index + 1) < subList.Count)
                {
                    Subtitle nextSub = subList[index + 1];

                    duration = Math.Min(duration, nextSub.StartMs - sub.StartMs);
                }

                // ensure positive
                duration = Math.Max(duration, 0);

                // test whether to update
                bool doUpdate = false;
                if (update == DurationUpdate.SetToCalculated)
                {
                    doUpdate = true;
                }
                else if (update == DurationUpdate.EmptyOnly)
                {
                    doUpdate = (sub.DurationMs == 0);
                }
                else
                {
                    doUpdate = (duration > sub.DurationMs);
                }

                // do the update!
                if (doUpdate)
                {
                    sub.DurationMs = duration;
                }
            }
        }

        void DoRenumber()
        {
            int idx = 1;
            foreach (Subtitle sub in subList)
            {
                sub.Number = idx++;
            }

            UpdateNextNewSubtitle();
        }

        void DoPlayCurrent()
        {
            if (VideoCurrentlyOpen)
            {
                int curStartMs = GetCurrentCellStart();

                if (curStartMs >= 0)
                {
                    int curStartSecs = Math.Max(curStartMs / 1000 - 1, 0);
                    SendSetPosition(curStartSecs);

                    if (!VideoCurrentlyPlaying)
                    {
                        SendPlayPause();
                    }
                }
            }
        }

        void DoFind(bool next)
        {
            int found = -1;
            int curPos = GetCurrentCellIndex();

            if (next)
            {
                for (int index = curPos + 1; index < subList.Count && found < 0; index++)
                {
                    if (FindFieldMatches(index))
                    {
                        found = index;
                    }
                }
                for (int index = 0; index < curPos && found < 0; index++)
                {
                    if (FindFieldMatches(index))
                    {
                        found = index;
                    }
                }
            }
            else
            {
                for (int index = curPos - 1; index >= 0 && found < 0; index--)
                {
                    if (FindFieldMatches(index))
                    {
                        found = index;
                    }
                }
                for (int index = subList.Count; index > curPos && found < 0; index--)
                {
                    if (FindFieldMatches(index))
                    {
                        found = index;
                    }
                }
            }

            if (found >= 0)
            {
                dataGridView.CurrentCell = dataGridView.Rows[found].Cells["SubText1"];
            }
        }

        bool FindFieldMatches(int index)
        {
            bool matches = false;

            if (index < subList.Count && toolStripTextBoxFind.Text != "")
            {
                Subtitle sub = subList[index];
                string combinedString = sub.SubText1 + "\n" + sub.SubText2 + "\n" + sub.SubText3 + "\n" + sub.SubText4;
                string testString = combinedString.ToLowerInvariant();
                string matchString = toolStripTextBoxFind.Text.ToLowerInvariant();

                if (ConfigForm.GetFindRegex())
                {
                    matches = Regex.IsMatch(testString, matchString);
                }
                else
                {
                    matches = testString.Contains(matchString);
                }
            }

            return matches;
        }

        // File Menu
        private void toolStripMenuItemNew_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Erase all subtitles?", "Confirm New", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SubtitleFileName[1] = "";
                SubtitleFileName[2] = "";
                SubtitleFileName[3] = "";
                SubtitleFileName[4] = "";
                subList = new BindingList<Subtitle>();
                dataGridView.DataSource = subList;
                UpdateUI();
                UpdateNextNewSubtitle();

                dataGridView.Columns["SubText2"].Visible = false;
                dataGridView.Columns["SubText3"].Visible = false;
                dataGridView.Columns["SubText4"].Visible = false;

                Text2Enabled = false;
                Text3Enabled = false;
                Text4Enabled = false;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                int count = 1;
                foreach (String file in openFileDialog.FileNames)
                {
                    if (count == 1)
                    {
                        DoOpenFile(file);
                    }
                    else
                    {
                        DoTextOpenByNumberFile(count, file);
                    }
                    count++;
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSaveFile(1);

            if (Text2Enabled)
            {
                DoSaveFile(2);
            }

            if (Text3Enabled)
            {
                DoSaveFile(3);
            }

            if (Text4Enabled)
            {
                DoSaveFile(4);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSaveAs(1);

            if (Text2Enabled)
            {
                DoSaveAs(2);
            }

            if (Text3Enabled)
            {
                DoSaveAs(3);
            }

            if (Text4Enabled)
            {
                DoSaveAs(4);
            }
        }

        private void connectToMPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SpawnMPC();
        }

        private void closeMPCtoolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendCloseMPC();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            ExitMPCApiApp();
        }

        // Edit Menu
        private void configurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ConfigForm config = new ConfigForm())
            {
                config.ShowDialog(this);
            }
        }

        private void toolStripMenuItemEditCurrent_Click(object sender, EventArgs e)
        {
            DoEditCurrent();
        }

        private void toolStripMenuItemInsert_Click(object sender, EventArgs e)
        {
            DoInsert();
        }

        private void toolStripMenuItemInsertBefore_Click(object sender, EventArgs e)
        {
            DoInsertBefore();
        }

        private void toolStripMenuItemInsertAfter_Click(object sender, EventArgs e)
        {
            DoInsertAfter();
        }

        private void toolStripMenuItemDelete_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void toolStripTextBoxFind_TextChanged(object sender, EventArgs e)
        {
            dataGridView.Refresh();
        }

        private void toolStripTextBoxFind_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    DoFind(false);
                }
                else
                {
                    DoFind(true);
                }
                e.Handled = true;
                dataGridView.Refresh();
            }
        }

        private void toolStripMenuItemFind_Click(object sender, EventArgs e)
        {
            toolStripTextBoxFind.Focus();
            toolStripTextBoxFind.SelectAll();
        }

        private void toolStripMenuItemFindPrevious_Click(object sender, EventArgs e)
        {
            DoFind(false);
        }

        private void toolStripMenuItemFindNext_Click(object sender, EventArgs e)
        {
            DoFind(true);
        }

        private void toolStripMenuItemReplace_Click(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItemAutoDuration_Click(object sender, EventArgs e)
        {
            DoDuration(DurationRange.Selected,
                DurationUpdate.SetToCalculated,
                DurationCalculation.Algorithm);
        }

        private void toolStripMenuItemEditNudgeTimes_Click(object sender, EventArgs e)
        {
            DoNudgeTimes();
        }

        private void toolStripMenuItemSetCurrentStart_Click(object sender, EventArgs e)
        {
            DoSetCurrentStart();
        }

        private void toolStripMenuItemSetCurrentEnd_Click(object sender, EventArgs e)
        {
            DoSetCurrentEnd();
        }

        // Navigate Menu
        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendPlayPause();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendStop();
        }

        private void seekToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSeek();
        }

        private void toolStripMenuResyncTime_Click(object sender, EventArgs e)
        {
            if (VideoCurrentlyOpen && VideoCurrentlyPlaying)
            {
                ResyncTime();
            }
            else
            {
                MessageBox.Show("Media Player Classic must be playing a video to Resync.");
            }
        }

        private void backwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1);
        }

        private void forwardSmallToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1);        
        }

        private void backwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5);
        }

        private void forwardMedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5);        
        }

        private void backwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20);
        }

        private void forwardBigToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20);        
        }

        private void backward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-1 * 60);        
        }

        private void forward1mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(1 * 60);        
        }

        private void backward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-5 * 60);        
        }

        private void forward5mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(5 * 60);        
        }

        private void backward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(-20 * 60);        
        }

        private void forward20mToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendJump(20 * 60);
        }

        // Tools
        private void fillInDurationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DurationForm duration = new DurationForm())
            {
                duration.ShowDialog(this);

                if (duration.ClosedWithOK == true)
                {
                    DoDuration(DurationForm.GetDurationRange(),
                        DurationForm.GetDurationUpdate(),
                        DurationForm.GetDurationCalculation());
                }
            }
        }

        // Context Menu
        private void toolStripMenuItemContextEditCurrent_Click(object sender, EventArgs e)
        {
            DoEditCurrent();
        }

        private void insertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoInsert();
        }

        private void insertBeforeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoInsertBefore();
        }

        private void insertAfterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoInsertAfter();
        }

        private void deleteStripMenuItem_Click(object sender, EventArgs e)
        {
            DoDelete();
        }

        private void nudgeTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoNudgeTimes();
        }

        private void setCurrentStartTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSetCurrentStart();
        }

        private void setCurrentEndTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoSetCurrentEnd();
        }

        // Datagrid
        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Ensure that the previous duration is updated when adding a row
            if (dataGridView.Rows[e.RowIndex].IsNewRow)
            {
                DoAutoDuration(e.RowIndex - 1);
            }
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string editedProperty = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
            
            if (editedProperty == "Start")
            {
                DoAutoDuration(e.RowIndex);
                DoAutoDuration(e.RowIndex - 1);
            }
            else if (editedProperty == "SubText1" || editedProperty == "SubText2" || editedProperty == "SubText3" || editedProperty == "SubText4")
            {
                DoAutoDuration(e.RowIndex);
                DoAutoDuration(e.RowIndex - 1);
            }
            dataGridView.Refresh();
        }

        private void dataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateNextNewSubtitle();
        }

        private void dataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int colIndex = e.ColumnIndex;
            int rowIndex = e.RowIndex;

            if (rowIndex >= 0 && colIndex >= 0)
            {
            }
        }

        private void dataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int colIndex = e.ColumnIndex;

            if (rowIndex >= 0 && colIndex >= 0 && rowIndex < subList.Count)
            {
                DataGridViewRow row = dataGridView.Rows[rowIndex];
                DataGridViewCell cell = row.Cells[colIndex];
                Color BackColor = System.Drawing.SystemColors.Window;
                Color SelectionBackColor = System.Drawing.SystemColors.Highlight;
                // cell.Style.ForeColor = System.Drawing.SystemColors.ControlText;
                // cell.Style.SelectionForeColor = System.Drawing.SystemColors.HighlightText;

                if (CurrentlyHighlightedRow == rowIndex)
                {
                    if (CurrentlyHighlightFullyLit)
                    {
                        // Darker blue
                        BackColor = Color.LightSkyBlue;
                        SelectionBackColor = Color.MediumBlue;
                    }
                    else
                    {
                        // Lighter blue
                        BackColor = Color.LightCyan;
                        SelectionBackColor = Color.DodgerBlue;
                    }
                }

                if (!row.IsNewRow)
                {
                    if (ConfigForm.GetHighlightInvalidCells())
                    {
                        Subtitle sub = subList[rowIndex];
                        Subtitle nextSub = null;

                        if ((rowIndex + 1) < subList.Count)
                        {
                            nextSub = subList[rowIndex + 1];
                        }

                        if (cell.OwningColumn.DataPropertyName == "SubText1" || cell.OwningColumn.DataPropertyName == "SubText2" || cell.OwningColumn.DataPropertyName == "SubText3" || cell.OwningColumn.DataPropertyName == "SubText4")
                        {
                            string text = sub.SubText1;

                            if (cell.OwningColumn.DataPropertyName == "SubText2")
                            {
                                text = sub.SubText2;
                            }
                            else if (cell.OwningColumn.DataPropertyName == "SubText3")
                            {
                                text = sub.SubText3;
                            }
                            else if (cell.OwningColumn.DataPropertyName == "SubText4")
                            {
                                text = sub.SubText4;
                            }

                            if (text == "")
                            {
                                BackColor = Color.Gold;
                                SelectionBackColor = Color.SaddleBrown;
                            }
                            else if (FindFieldMatches(rowIndex))
                            {
                                BackColor = Color.PaleGreen;
                                SelectionBackColor = Color.DarkGreen;
                            }
                        }

                        if (cell.OwningColumn.DataPropertyName == "End")
                        {
                            if (sub.StartMs > sub.EndMs)
                            {
                                BackColor = Color.LightCoral;
                                SelectionBackColor = Color.DarkRed;
                            }
                            else if (nextSub != null && sub.EndMs > nextSub.StartMs)
                            {
                                BackColor = Color.Gold;
                                SelectionBackColor = Color.SaddleBrown;
                            }
                        }

                        if (cell.OwningColumn.DataPropertyName == "Duration")
                        {
                            if (sub.DurationMs < ConfigForm.GetDurationMinimum())
                            {
                                BackColor = Color.Gold;
                                SelectionBackColor = Color.SaddleBrown;
                            }
                        }
                    }
                }

                if (BackColor != cell.Style.BackColor)
                {
                    cell.Style.BackColor = BackColor;
                }

                if (SelectionBackColor != cell.Style.SelectionBackColor)
                {
                    cell.Style.SelectionBackColor = SelectionBackColor;
                }
            }
        }


        // Notification Overrides
        protected override void NotifyConnected()
        {
            toolStripMPCState.Text = "Connected";
            UpdateUI();
        }

        protected override void NotifyClosed() 
        {
            toolStripMPCState.Text = "Connected";
            UpdateUI();
        }
        
        protected override void NotifyLoading()
        {
            toolStripMPCState.Text = "Loading Video File";
            UpdateUI();
        }
        
        protected override void NotifyLoaded()
        {
            toolStripMPCState.Text = "Video File Loaded";
            UpdateUI();
        }
        
        protected override void NotifyClosing() 
        {
            toolStripMPCState.Text = "Closing";
            UpdateUI();
        }
        
        protected override void NotifyPlay()
        {
            toolStripMPCState.Text = "Playing";
            UpdateUI();
        }
        
        protected override void NotifyPause()
        {
            toolStripMPCState.Text = "Paused";
            UpdateUI();
        }
        
        protected override void NotifyStop()
        {
            toolStripMPCState.Text = "Stopped";
            UpdateUI();
        }

        protected override void NotifyNowPlaying(string title, string author, string description, string filename, int duration)
        {
            UpdateUI();
        }

        private void toolStripMPCState_Click(object sender, EventArgs e)
        {
            SpawnMPC();
        }

        private void videoFiletoolStripStatusLabel_Click(object sender, EventArgs e)
        {
            SpawnMPC();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();

            aboutBox.ShowDialog();
        }

        private void toolStripTextBoxCurrentTime_Click(object sender, EventArgs e)
        {
            DoSeek();
            dataGridView.Focus();
        }

        private void autoFollowCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            toolStripMenuItemAutoFollow.Checked = autoFollowCheckBox.Checked;
        }

        private void toolStripMenuItemAutoFollow_Click(object sender, EventArgs e)
        {
            if (toolStripMenuItemAutoFollow.Checked)
            {
                toolStripMenuItemAutoFollow.Checked = false;
                autoFollowCheckBox.Checked = false;
            }
            else
            {
                toolStripMenuItemAutoFollow.Checked = true;
                autoFollowCheckBox.Checked = true;
            }
        }

        // Play Current Subtitle
        private void toolStripMenuItemNavPlayCurrent_Click(object sender, EventArgs e)
        {
            DoPlayCurrent();
        }

        private void toolStripMenuItemEditPlayCurrent_Click(object sender, EventArgs e)
        {
            DoPlayCurrent();
        }

        private void toolStripMenuItemContextPlayCurrent_Click(object sender, EventArgs e)
        {
            DoPlayCurrent();
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DoPlayCurrent();
        }

        private void toolStripMenuItemOverlay_Click(object sender, EventArgs e)
        {
            if (overlay == null)
            {
                overlay = new Overlay(this);
                overlay.Show();
                Refresh();
                toolStripMenuItemOverlay.Checked = true;
            }
            else
            {
                overlay.Close();
                OverlayClosed();
            }
        }

        public void OverlayClosed()
        {
            overlay = null;
            toolStripMenuItemOverlay.Checked = false;
        }

        private void toolStripMenuItemAppendFile_Click(object sender, EventArgs e)
        {
            using (AppendForm append = new AppendForm(GetLastSubtitleEndTime()))
            {
                append.ShowDialog(this);

                if (append.okClicked)
                {
                    Cursor.Current = Cursors.WaitCursor;

                    DialogResult result = appendFileDialog.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        DoAppendFile(appendFileDialog.FileName, append.GetSeekTime());
                    }
                }
            }
        }

        // Split/join

        private void split2WaysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void split3WaysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void split4WaysToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        public static int CountStringOccurrences(string text, string pattern)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = text.IndexOf(pattern, i)) != -1)
            {
                i += pattern.Length;
                count++;
            }
            return count;
        }
        
        int LineLength(string s)
        {
            return CountStringOccurrences(s, "\n") + 1;
        }

        int LongestLine(Subtitle sub)
        {
            int longest = LineLength(sub.SubText1);
            longest = Math.Max(longest, LineLength(sub.SubText2));
            longest = Math.Max(longest, LineLength(sub.SubText3));
            longest = Math.Max(longest, LineLength(sub.SubText4));
            return longest;
        }

        private void mergeDownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Subtitle sub in subList)
            {
                string newsubtext = sub.SubText1;

                if (Text2Enabled)
                {
                    newsubtext = newsubtext + "\r\n" + sub.SubText2;
                    
                    if (Text3Enabled)
                    {
                        newsubtext = newsubtext + "\r\n" + sub.SubText3;

                        if (Text4Enabled)
                        {
                            newsubtext = newsubtext + "\r\n" + sub.SubText4;
                        }
                    }
                }

                sub.SubText1 = newsubtext;
                sub.SubText2 = "";
                sub.SubText3 = "";
                sub.SubText4 = "";
            }

            Text2Enabled = false;
            Text3Enabled = false;
            Text4Enabled = false;

            dataGridView.Columns["SubText2"].Visible = false;
            dataGridView.Columns["SubText3"].Visible = false;
            dataGridView.Columns["SubText4"].Visible = false;
        }

        // Text 1-4 Submenu

        // New
        private void toolStripMenuItemText1New_Click(object sender, EventArgs e)
        {
            foreach (Subtitle sub in subList)
            {
                sub.SubText1 = "";
            }
        }

        private void toolStripMenuItemText2New_Click(object sender, EventArgs e)
        {
            Text2Enabled = true;
            dataGridView.Columns["SubText2"].Visible = true;
            foreach (Subtitle sub in subList)
            {
                sub.SubText2 = "";
            }
        }

        private void toolStripMenuItemText3New_Click(object sender, EventArgs e)
        {
            Text3Enabled = true;
            dataGridView.Columns["SubText3"].Visible = true;
            foreach (Subtitle sub in subList)
            {
                sub.SubText3 = "";
            }
        }

        private void toolStripMenuItemText4New_Click(object sender, EventArgs e)
        {
            Text4Enabled = true;
            dataGridView.Columns["SubText4"].Visible = true;
            foreach (Subtitle sub in subList)
            {
                sub.SubText4 = "";
            }
        }

        // Open

        private void toolStripMenuItemText1Open_Click(object sender, EventArgs e)
        {
            DoTextOpenByNumber(1);
        }

        private void toolStripMenuItemText2Open_Click(object sender, EventArgs e)
        {
            DoTextOpenByNumber(2);
        }

        private void toolStripMenuItemText3Open_Click(object sender, EventArgs e)
        {
            DoTextOpenByNumber(3);
        }

        private void toolStripMenuItemText4Open_Click(object sender, EventArgs e)
        {
            DoTextOpenByNumber(4);
        }

        void DoTextOpenByNumber(int textNum)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                DoTextOpenByNumberFile(textNum, openFileDialog.FileName);
            }
        }


        void DoTextOpenByNumberFile(int textNum, string fileName)
        {
            Cursor.Current = Cursors.WaitCursor;

            BindingList<Subtitle> subListTemp = Subtitle.ReadSubtitleFile(fileName);
            if (subListTemp != null)
            {
                SubtitleFileName[textNum] = fileName;

                int count = 0;
                foreach (Subtitle sub in subListTemp)
                {
                    if (count >= subList.Count())
                    {
                        string temp = sub.SubText1;
                        sub.SubText1 = "";
                        sub.SetSubText(textNum, temp);
                        subList.Add(sub);
                    }
                    else
                    {
                        subList[count].SetSubText(textNum, sub.SubText1);
                    }
                    count++;
                }

                for (int i = count; i < subList.Count(); i++)
                {
                    subList[i].SetSubText(textNum, "");
                }

                if (textNum == 2)
                {
                    Text2Enabled = true;
                }
                else if (textNum == 3)
                {
                    Text3Enabled = true;
                }
                else if (textNum == 4)
                {
                    Text4Enabled = true;
                }

                dataGridView.Columns[Subtitle.GetSubTextName(textNum)].Visible = true;

                UpdateUI();
                DoRenumber();
            }
        }

        private void openNearestTimeText1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpenNearestTime(1);
        }

        private void openNearestTimeText2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpenNearestTime(2);
        }

        private void openNearestTimeTex3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpenNearestTime(3);
        }

        private void openNearestTimeText4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoOpenNearestTime(4);
        }

        void DoOpenNearestTime(int textNum)
        {
            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                Cursor.Current = Cursors.WaitCursor;

                int lastEndTime = GetLastSubtitleEndTime();

                BindingList<Subtitle> subListTemp = Subtitle.ReadSubtitleFile(openFileDialog.FileName);
         
                if (subListTemp != null && subList.Count() > 0)
                {
                    SubtitleFileName[textNum] = openFileDialog.FileName;

                    foreach (Subtitle sub in subList)
                    {
                        sub.SetSubText(textNum, "");
                    }

                    int bestMatchIdx = 0;
                    int bestMatchOverlap = 0;

                    foreach (Subtitle subTemp in subListTemp)
                    {
                        if ((subTemp.StartMs - lastEndTime) > 5000)
                        {
                            string temp = subTemp.SubText1;
                            subTemp.SubText1 = "";
                            subTemp.SetSubText(textNum, temp);
                            subList.Add(subTemp);
                        }
                        else
                        {
                            bestMatchOverlap = subList[bestMatchIdx].GetOverlap(subTemp);

                            while ((bestMatchIdx + 1) < subList.Count())
                            {
                                int testOverlap = subList[bestMatchIdx + 1].GetOverlap(subTemp);

                                if (testOverlap > bestMatchOverlap)
                                {
                                    bestMatchOverlap = testOverlap;
                                    bestMatchIdx++;
                                }
                                else
                                {
                                    break;
                                }
                            }

                            if (bestMatchOverlap > 0)
                            {
                                string current = subList[bestMatchIdx].GetSubText(textNum);

                                if (current == "")
                                {
                                    subList[bestMatchIdx].SetSubText(textNum, subTemp.SubText1);
                                }
                                else
                                {
                                    subList[bestMatchIdx].SetSubText(textNum, current + "\n" + subTemp.SubText1);
                                }
                            }
                            else
                            {
                                // There was no overlap, insert a new subtitle, either before or after the 'best' match
                                if (subTemp.StartMs >= subList[bestMatchIdx].StartMs)
                                {
                                    // Insert it after the best match
                                    bestMatchIdx++;
                                }

                                string tempText = subTemp.SubText1;
                                subTemp.SubText1 = "";
                                subTemp.SetSubText(textNum, tempText);
                                subList.Insert(bestMatchIdx, subTemp);
                            }
                        }
                    }
                }

                if (textNum == 2)
                {
                    Text2Enabled = true;
                }
                else if (textNum == 3)
                {
                    Text3Enabled = true;
                }
                else if (textNum == 4)
                {
                    Text4Enabled = true;
                }

                dataGridView.Columns[Subtitle.GetSubTextName(textNum)].Visible = true;
                UpdateUI();
                DoRenumber();
            }
        }

        // Save

        private void toolStripMenuItemText1Save_Click(object sender, EventArgs e)
        {
            if (SubtitleFileName[1].Length > 0)
            {
                WriteFile(SubtitleFileName[1], 1);
            }
        }

        private void toolStripMenuItemText2Save_Click(object sender, EventArgs e)
        {
            if (SubtitleFileName[2].Length > 0)
            {
                WriteFile(SubtitleFileName[2], 2);
            }
        }

        private void toolStripMenuItemText3Save_Click(object sender, EventArgs e)
        {
            if (SubtitleFileName[3].Length > 0)
            {
                WriteFile(SubtitleFileName[3], 3);
            }
        }

        private void toolStripMenuItemText4Save_Click(object sender, EventArgs e)
        {
            if (SubtitleFileName[4].Length > 0)
            {
                WriteFile(SubtitleFileName[4], 4);
            }
        }

        // Save As

        private void toolStripMenuItemText1SaveAs_Click(object sender, EventArgs e)
        {
            DoSaveAs(1);
        }

        private void toolStripMenuItemText2SaveAs_Click(object sender, EventArgs e)
        {
            DoSaveAs(2);
        }

        private void toolStripMenuItemText3SaveAs_Click(object sender, EventArgs e)
        {
            DoSaveAs(3);
        }

        private void toolStripMenuItemText4SaveAs_Click(object sender, EventArgs e)
        {
            DoSaveAs(4);
        }

        //Copy

        private void toolStripMenuItemText1Copy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextCopy(1);
        }

        private void toolStripMenuItemText2Copy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextCopy(2);
        }

        private void toolStripMenuItemText3Copy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextCopy(3);
        }

        private void toolStripMenuItemText4Copy_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextCopy(4);
        }


        void DoTextCopy(int textNum)
        {
            string buffer = "";

            foreach (Subtitle sub in subList)
            {
                buffer += sub.GetSubText(textNum).Replace("\r\n", "\t").Replace("\n", "\t");
                buffer += "\r\n";
            }

            Clipboard.SetDataObject(buffer, true);
        }

        // Paste

        private void toolStripMenuItemText1Paste_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

        }

        private void toolStripMenuItemText2Paste_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
        }

        private void toolStripMenuItemText3Paste_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

        }

        private void toolStripMenuItemText4Paste_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

        }

        // Move left/right

        private void toolStripMenuItemText1MoveRight_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(1, 2);
        }

        private void toolStripMenuItemText2MoveLeft_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(1, 2);
        }

        private void toolStripMenuItemText2MoveRight_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(2, 3);
        }

        private void toolStripMenuItemText3MoveLeft_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(2, 3);
        }

        private void toolStripMenuItemText3MoveRight_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(3, 4);
        }

        private void toolStripMenuItemText4MoveLeft_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsMove(3, 4);
        }

        void DoTextColumnsMove(int left, int right)
        {
            Cursor.Current = Cursors.WaitCursor;
            
            foreach (Subtitle sub in subList)
            {
                string leftStr = sub.GetSubText(left);
                string rightStr = sub.GetSubText(right);
                sub.SetSubText(right, leftStr);
                sub.SetSubText(left, rightStr);
            }

            string temp = SubtitleFileName[right];
            SubtitleFileName[right] = SubtitleFileName[left];
            SubtitleFileName[left] = temp;
        }


        private void toolStripMenuItemText1Duplicate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsDuplicate(1);
        }

        private void toolStripMenuItemText2Duplicate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsDuplicate(2);
        }

        private void toolStripMenuItemText3Duplicate_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoTextColumnsDuplicate(3);
        }

        void DoTextColumnsDuplicate(int from)
        {
            Cursor.Current = Cursors.WaitCursor;
            int to = from;

            if (!Text2Enabled)
            {
                to = 2;
                Text2Enabled = true;
            }
            else if (Text2Enabled && !Text3Enabled)
            {
                to = 3;
                Text3Enabled = true;
            }
            else if (Text3Enabled && !Text4Enabled)
            {
                to = 4;
                Text4Enabled = true;
            }

            foreach (Subtitle sub in subList)
            {
                sub.SetSubText(to, sub.GetSubText(from));
            }

            dataGridView.Columns[Subtitle.GetSubTextName(to)].Visible = true;
            UpdateUI();
            DoRenumber();
        }

        // Delete

        private void toolStripMenuItemText1Delete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoDeleteText(1);
        }

        private void toolStripMenuItemText2Delete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoDeleteText(2);
        }

        private void toolStripMenuItemText3Delete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoDeleteText(3);
        }

        private void toolStripMenuItemText4Delete_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DoDeleteText(4);
        }

        void DoDeleteText(int num)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (num == 1 && Text2Enabled
                || num == 2 && Text3Enabled
                || num == 3 && Text4Enabled)
            {
                DoTextColumnsMove(num, num + 1);
                DoDeleteText(num + 1);
            }
            else
            {
                foreach (Subtitle sub in subList)
                {
                    sub.SetSubText(num, "");
                }
                dataGridView.Columns[Subtitle.GetSubTextName(num)].Visible = false;

                if (num == 2)
                {
                    Text2Enabled = false;
                }
                else if (num == 3)
                {
                    Text3Enabled = false;
                }
                else if (num == 4)
                {
                    Text4Enabled = false;
                }
            }
        }

        // enable disable menu items
        void toolStripMenuItemFile_DropDownOpened(object sender, System.EventArgs e)
        {
            saveToolStripMenuItem.Enabled = SubtitleFileName[1].Length > 0;
            toolStripMenuItemAppendFile.Enabled = !Text2Enabled;
        }

        void toolStripMenuLanguages_DropDownOpened(object sender, System.EventArgs e)
        {
            toolStripMenuText3.Enabled = Text2Enabled;
            toolStripMenuText4.Enabled = Text3Enabled;
        }

        private void toolStripMenuText1_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItemText1Save.Enabled = SubtitleFileName[1].Length > 0;
            toolStripMenuItemText1MoveRight.Enabled = Text2Enabled;
            toolStripMenuItemText1Duplicate.Enabled = !Text4Enabled;
        }

        private void toolStripMenuText2_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItemText2Save.Enabled = Text2Enabled && SubtitleFileName[2].Length > 0;
            toolStripMenuItemText2SaveAs.Enabled = Text2Enabled;
            toolStripMenuItemText2Copy.Enabled = Text2Enabled;
            toolStripMenuItemText2Paste.Enabled = Text2Enabled;
            toolStripMenuItemText2MoveLeft.Enabled = Text2Enabled;
            toolStripMenuItemText2MoveRight.Enabled = Text3Enabled;
            toolStripMenuItemText2Duplicate.Enabled = Text2Enabled && !Text4Enabled;
            toolStripMenuItemText2Delete.Enabled = Text2Enabled;
        }

        private void toolStripMenuText3_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItemText3Save.Enabled = Text3Enabled && SubtitleFileName[3].Length > 0;
            toolStripMenuItemText3SaveAs.Enabled = Text3Enabled;
            toolStripMenuItemText3Copy.Enabled = Text3Enabled;
            toolStripMenuItemText3Paste.Enabled = Text3Enabled;
            toolStripMenuItemText3MoveLeft.Enabled = Text3Enabled;
            toolStripMenuItemText3MoveRight.Enabled = Text4Enabled;
            toolStripMenuItemText3Duplicate.Enabled = Text3Enabled && !Text4Enabled;
            toolStripMenuItemText3Delete.Enabled = Text3Enabled;
        }

        private void toolStripMenuText4_DropDownOpened(object sender, EventArgs e)
        {
            toolStripMenuItemText4Save.Enabled = Text4Enabled && SubtitleFileName[4].Length > 0;
            toolStripMenuItemText4SaveAs.Enabled = Text4Enabled;
            toolStripMenuItemText4Copy.Enabled = Text4Enabled;
            toolStripMenuItemText4Paste.Enabled = Text4Enabled;
            toolStripMenuItemText4Delete.Enabled = Text4Enabled;
            toolStripMenuItemText4MoveLeft.Enabled = Text4Enabled;
        }

        void toolStripMenuSplitMerge_DropDownOpened(object sender, System.EventArgs e)
        {
            split2WaysToolStripMenuItem.Enabled = !Text2Enabled;
            split3WaysToolStripMenuItem.Enabled = !Text2Enabled;
            split4WaysToolStripMenuItem.Enabled = !Text2Enabled;
            mergeDownToolStripMenuItem.Enabled = Text2Enabled;
        }

        private void editToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
        }

        private void navigationToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void toolsToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {

        }

        private void googleTranslateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoogleTranslate translate = new GoogleTranslate(this);

            translate.ShowDialog(this);

            if (translate.okClicked)
            {
                Cursor.Current = Cursors.WaitCursor;

                int radioSetting = GoogleTranslate.GetTextRadioSetting();

                if (radioSetting == 0)
                {
                    if (dataGridView.SelectedCells != null && subList.Count > 0)
                    {
                        var sources = new List<string>();
                        var translations = new List<string>();

                        foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                        {
                            if (cell.RowIndex < subList.Count)
                            {
                                if (cell.OwningColumn.DataPropertyName == "SubText1")
                                {
                                    sources.Add(subList[cell.RowIndex].SubText1);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText2")
                                {
                                    sources.Add(subList[cell.RowIndex].SubText2);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText3")
                                {
                                    sources.Add(subList[cell.RowIndex].SubText3);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText4")
                                {
                                    sources.Add(subList[cell.RowIndex].SubText4);
                                }
                            }
                        }

                        translate.DoTranslate(sources, ref translations);

                        int i = 0;
                        foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                        {
                            if (cell.RowIndex < subList.Count)
                            {
                                if (cell.OwningColumn.DataPropertyName == "SubText1")
                                {
                                    subList[cell.RowIndex].SubText1 = translations[i];
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText2")
                                {
                                    subList[cell.RowIndex].SubText2 = translations[i];
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText3")
                                {
                                    subList[cell.RowIndex].SubText3 = translations[i];
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText4")
                                {
                                    subList[cell.RowIndex].SubText4 = translations[i];
                                }
                                i++;
                            }
                        }
                    }
                }
                else
                {
                    var sources = new List<string>();
                    var translations = new List<string>();

                    foreach (Subtitle sub in subList)
                    {
                        sources.Add(sub.GetSubText(radioSetting));
                    }

                    translate.DoTranslate(sources, ref translations);

                    int i = 0;
                    foreach (Subtitle sub in subList)
                    {
                        sub.SetSubText(radioSetting, translations[i]);
                        i++;
                    }
                }
            }
        }

        private void toolStripMenuSplitMerge_Click(object sender, EventArgs e)
        {

        }

        private void chineseToolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chinese chinese = new Chinese(this);

            chinese.ShowDialog(this);

            if (chinese.okClicked)
            {
                Cursor.Current = Cursors.WaitCursor;

                int radioSetting = Chinese.GetTextRadioSetting();

                if (radioSetting == 0)
                {
                    if (dataGridView.SelectedCells != null && subList.Count > 0)
                    {
                        var sources = new List<string>();
                        var translations = new List<string>();

                        foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                        {
                            if (cell.RowIndex < subList.Count)
                            {
                                if (cell.OwningColumn.DataPropertyName == "SubText1")
                                {
                                    subList[cell.RowIndex].SubText1 = chinese.Translate(subList[cell.RowIndex].SubText1);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText2")
                                {
                                    subList[cell.RowIndex].SubText2 = chinese.Translate(subList[cell.RowIndex].SubText2);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText3")
                                {
                                    subList[cell.RowIndex].SubText3 = chinese.Translate(subList[cell.RowIndex].SubText3);
                                }
                                else if (cell.OwningColumn.DataPropertyName == "SubText4")
                                {
                                    subList[cell.RowIndex].SubText4 = chinese.Translate(subList[cell.RowIndex].SubText4);
                                }
                            }
                        }
                    }
                }
                else
                {
                    foreach (Subtitle sub in subList)
                    {
                        sub.SetSubText(radioSetting, chinese.Translate(sub.GetSubText(radioSetting)));
                    }
                }
            }
        }

        private void chineseDictionaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClassicSub.Forms.ChineseDict chinese = new ClassicSub.Forms.ChineseDict(this);

            chinese.ShowDialog(this);
        }

        private void buttonFindNext_Click(object sender, EventArgs e)
        {
            DoFind(true);
        }

        private void buttonFindPrev_Click(object sender, EventArgs e)
        {
            DoFind(false);
        }

        private void toolsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showOverlayContextMenuToolStripMenuItem.Enabled = (overlay != null);
        }

        private void showOverlayContextMenuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (overlay != null)
            {
                Point middle = new Point(overlay.ClientRectangle.Left + overlay.ClientSize.Width / 2,
                                         overlay.ClientRectangle.Top + overlay.ClientSize.Height / 2);
                overlay.ContextMenuStrip.Show(middle);
            }
        }
    }
}

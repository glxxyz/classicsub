using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Text;
using TestDesignerCSLibrary;
using ClassicSub.Forms;


namespace ClassicSub
{
    public partial class Overlay : Form
    {
        /// <summary>Values to pass to the GetDCEx method.</summary>
        [Flags()]
        private enum DeviceContextValues : uint
        {
            /// <summary>DCX_WINDOW: Returns a DC that corresponds to the window rectangle rather 
            /// than the client rectangle.</summary>
            Window = 0x00000001,
            /// <summary>DCX_CACHE: Returns a DC from the cache, rather than the OWNDC or CLASSDC 
            /// window. Essentially overrides CS_OWNDC and CS_CLASSDC.</summary>
            Cache = 0x00000002,
            /// <summary>DCX_NORESETATTRS: Does not reset the attributes of this DC to the 
            /// default attributes when this DC is released.</summary>
            NoResetAttrs = 0x00000004,
            /// <summary>DCX_CLIPCHILDREN: Excludes the visible regions of all child windows 
            /// below the window identified by hWnd.</summary>
            ClipChildren = 0x00000008,
            /// <summary>DCX_CLIPSIBLINGS: Excludes the visible regions of all sibling windows 
            /// above the window identified by hWnd.</summary>
            ClipSiblings = 0x00000010,
            /// <summary>DCX_PARENTCLIP: Uses the visible region of the parent window. The 
            /// parent's WS_CLIPCHILDREN and CS_PARENTDC style bits are ignored. The origin is 
            /// set to the upper-left corner of the window identified by hWnd.</summary>
            ParentClip = 0x00000020,
            /// <summary>DCX_EXCLUDERGN: The clipping region identified by hrgnClip is excluded 
            /// from the visible region of the returned DC.</summary>
            ExcludeRgn = 0x00000040,
            /// <summary>DCX_INTERSECTRGN: The clipping region identified by hrgnClip is 
            /// intersected with the visible region of the returned DC.</summary>
            IntersectRgn = 0x00000080,
            /// <summary>DCX_EXCLUDEUPDATE: Unknown...Undocumented</summary>
            ExcludeUpdate = 0x00000100,
            /// <summary>DCX_INTERSECTUPDATE: Unknown...Undocumented</summary>
            IntersectUpdate = 0x00000200,
            /// <summary>DCX_LOCKWINDOWUPDATE: Allows drawing even if there is a LockWindowUpdate 
            /// call in effect that would otherwise exclude this window. Used for drawing during 
            /// tracking.</summary>
            LockWindowUpdate = 0x00000400,
            /// <summary>DCX_VALIDATE When specified with DCX_INTERSECTUPDATE, causes the DC to 
            /// be completely validated. Using this function with both DCX_INTERSECTUPDATE and 
            /// DCX_VALIDATE is identical to using the BeginPaint function.</summary>
            Validate = 0x00200000,
        }

        // Win32 Imports
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

        [DllImport("User32.dll")]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, DeviceContextValues flags);

        private enum RedrawWindowFlags : uint { }
        [DllImport("user32.dll")]
        static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags); 

        private ClassicSubForm parent;
        public string SubTitleText = "";
        int SubTitleMaxSize = 24;
        bool HideBorders = true;
        int MinSubtitleSize = 10;
        
        public Overlay(ClassicSubForm p)
        {
            parent = p;

            InitializeComponent();
            this.ControlBox = false;
            this.Text = string.Empty;
            TopMost = true;

            FormBorderStyle = FormBorderStyle.None;

//            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
 //           BackColor = Color.Transparent;
 //           this.ResizeRedraw = true;
        }

 /* */       protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            SolidBrush black = new SolidBrush(Color.FromArgb(255, BackColor));
            
           e.Graphics.FillRectangle(black, ClientRectangle);

            e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            int testSubTitleMaxSize = SubTitleMaxSize;
            Font TextFont = new Font("Arial", testSubTitleMaxSize, FontStyle.Regular);
            SizeF size = e.Graphics.MeasureString(SubTitleText, TextFont);

            // make the font smaller to fit on screen
            while (   (size.Width > ClientRectangle.Width || size.Height > ClientRectangle.Height)
                   && (testSubTitleMaxSize >= MinSubtitleSize))
            {
                testSubTitleMaxSize -= 1;
                TextFont = new Font("Arial", testSubTitleMaxSize, FontStyle.Regular);
                size = e.Graphics.MeasureString(SubTitleText, TextFont);
            }

            StringFormat stringFormat = new StringFormat();

            if (leftToolStripMenuItem.Checked)
            {
                stringFormat.Alignment = StringAlignment.Near;
            }
            else if (centerToolStripMenuItem.Checked)
           {
                stringFormat.Alignment = StringAlignment.Center;
            }
            else
            {
                stringFormat.Alignment = StringAlignment.Far;
            }

            if (topToolStripMenuItem.Checked)
            {
                stringFormat.LineAlignment = StringAlignment.Near;
            }
            else if (middleToolStripMenuItem.Checked)
            {
                stringFormat.LineAlignment = StringAlignment.Center;
            }
            else
            {
                stringFormat.LineAlignment = StringAlignment.Far;
            }

            SolidBrush white = new SolidBrush(ForeColor);
            e.Graphics.DrawString(SubTitleText, TextFont, white, ClientRectangle, stringFormat);
        }
        /*
        //using TestDesignerCSLibrary;
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;

            //Drawing the back ground color
            Color m_clrBkgd = Color.FromArgb(255, 255, 255);
            SolidBrush brushBkgnd = new SolidBrush(m_clrBkgd);
            e.Graphics.FillRectangle(brushBkgnd, 0, 0, this.ClientSize.Width, this.ClientSize.Width);

            PngOutlineText m_PngOutlineText = new PngOutlineText();
            m_PngOutlineText.TextOutline(
                Color.FromArgb(255, 128, 192),
                Color.FromArgb(255, 200, 0, 0),
                4);

            m_PngOutlineText.EnableShadow(true);
            //Rem to SetNullShadow() to release memory if a previous shadow has been set.
            m_PngOutlineText.SetNullShadow();
            m_PngOutlineText.Shadow(
                Color.FromArgb(128, 0, 0, 0), 4,
                new Point(4, 4));
            m_PngOutlineText.SetShadowBkgd(m_clrBkgd, this.ClientSize.Width, this.ClientSize.Height);
            bool m_bDirty = true;
            Bitmap m_pPngImage = null;
            FontFamily fontFamily = new FontFamily("Arial Black");

            StringFormat strFormat = new StringFormat();
            if (m_bDirty == false && m_pPngImage != null)
            {
                e.Graphics.DrawImage(m_pPngImage, 0, 0, m_pPngImage.Width, m_pPngImage.Height);
                e.Graphics.Dispose();
                return;
            }

            m_pPngImage = new Bitmap(this.ClientSize.Width, this.ClientSize.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            m_PngOutlineText.SetPngImage(m_pPngImage);
            float fDestWidth = 0.0f;
            float fDestHeight = 0.0f;
            m_PngOutlineText.MeasureString(
                e.Graphics,
                fontFamily,
                FontStyle.Regular,
                48,
                "Text Designer",
        new Point(10, 10),
                strFormat,
                ref fDestWidth,
                ref fDestHeight);
            LinearGradientBrush gradientBrush = new LinearGradientBrush(new Rectangle(10, 10, (int)fDestWidth, (int)fDestHeight),
                Color.FromArgb(255, 128, 192), Color.FromArgb(255, 0, 0), LinearGradientMode.Vertical);
            m_PngOutlineText.TextOutline(
                gradientBrush,
                Color.FromArgb(255, 200, 0, 0),
                4);
            m_PngOutlineText.DrawString(e.Graphics, fontFamily,
                FontStyle.Regular, 48, "Text Designer",
                 new Point(10, 10), strFormat);
            e.Graphics.DrawImage(m_pPngImage, 0, 0, m_pPngImage.Width, m_pPngImage.Height);

            e.Graphics.Dispose();
        }
        */

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            SolidBrush black = new SolidBrush(Color.FromArgb(0, BackColor));
            e.Graphics.FillRectangle(black, ClientRectangle);
        }

        protected override void WndProc(ref Message m)
        {
            const int WM_NCPAINT = 0x85;
//            const int WM_PAINT = 0xF;
//            const int WM_ERASEBKGND = 0x14;

            if (m.Msg == WM_NCPAINT && HideBorders)
            {
                IntPtr hdc = GetWindowDC(m.HWnd);
                // Try to get it this way for Windows 7 to hide the border!
                // See http://msdn.microsoft.com/en-us/library/dd145212(v=vs.85).aspx
                // Mmm those ORs and CASTs are just lovely
                // IntPtr hdc = GetDCEx(m.HWnd, m.WParam, (DeviceContextValues)((UInt32)DeviceContextValues.Window | (UInt32)DeviceContextValues.IntersectRgn | 0x10000));

                if ((int)hdc != 0)
                {
                    Graphics g = Graphics.FromHdc(hdc);
                    SolidBrush black = new SolidBrush(Color.FromArgb(0, BackColor));
                    g.FillRectangle(black, 0, 0, Width, Height);
                    g.Flush();
                    g.Dispose();
                    ReleaseDC(m.HWnd, hdc);
                }
            }
            else if (m.Msg == 0x84 && HideBorders) // Trap WM_NCHITTEST
            {            
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                pos = this.PointToClient(pos);

                const int HTLEFT = 10;
                const int HTRIGHT = 11;
                const int HTTOP = 12;
                const int HTTOPLEFT = 13;
                const int HTTOPRIGHT = 14;
                const int HTBOTTOM = 15;
                const int HTBOTTOMLEFT = 0x10;
                const int HTBOTTOMRIGHT = 17;

                if (pos.X <= 5 && pos.Y <= 5)
                    m.Result = (IntPtr)HTTOPLEFT;
                else if (pos.X <= 5 && pos.Y >= ClientSize.Height - 5)
                    m.Result = (IntPtr)HTBOTTOMLEFT;
                else if (pos.X <= 5)
                    m.Result = (IntPtr)HTLEFT;
                else if ((pos.X >= ClientSize.Width - 5) && pos.Y <= 5)
                    m.Result = (IntPtr)HTTOPRIGHT;
                else if ((pos.X >= ClientSize.Width - 5) && pos.Y >= ClientSize.Height - 5)
                    m.Result = (IntPtr)HTBOTTOMRIGHT;
                else if (pos.X >= ClientSize.Width - 5) 
                    m.Result = (IntPtr)HTRIGHT;
                else if (pos.Y <= 5)
                    m.Result = (IntPtr)HTTOP;
                else if (pos.Y >= ClientSize.Height - 5)
                    m.Result = (IntPtr)HTBOTTOM;
                else
                    base.WndProc(ref m);


                // Old version
                /*
                const int cGrip = 16;      // Grip size
                const int cCaption = 25;   // Caption bar height;
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                }
                else if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
                else
                {
                    base.WndProc(ref m);
                }*/
            }
            else
            {
                base.WndProc(ref m);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (   keyData != (Keys.Alt | Keys.W)
                && keyData != (Keys.Alt | Keys.H)
                && keyData != (Keys.Alt | Keys.Left)
                && keyData != (Keys.Alt | Keys.Right))
            {

                return parent.DoProcessCmdKey(ref msg, keyData);
            }

            return base.ProcessCmdKey(ref msg, keyData); //we didn't handle it
        }


        public void SetSubtitle(string text)
        {
            SubTitleText = text;
            Refresh();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            parent.OverlayClosed();
            Close();
        }

        private void increaseFontSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubTitleMaxSize += 2;
            Refresh();
        }

        private void decreaseFontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SubTitleMaxSize = Math.Max(SubTitleMaxSize - 2, MinSubtitleSize);
            Refresh();
        }

        private void hideBordersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hideBordersToolStripMenuItem.Checked = !hideBordersToolStripMenuItem.Checked;
            HideBorders = hideBordersToolStripMenuItem.Checked;

            if (HideBorders)
            {
                FormBorderStyle = FormBorderStyle.None;
            }
            else
            {
                FormBorderStyle = FormBorderStyle.Sizable;
            }
                
            // Invalidate the Client area
            Refresh();

            // Invalidate the nonclient area
            RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, (RedrawWindowFlags)(0x0400/*RDW_FRAME*/ | 0x0100/*RDW_UPDATENOW*/ | 0x0001/*RDW_INVALIDATE*/));
        }

        private void topmostWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topmostWindowToolStripMenuItem.Checked = !topmostWindowToolStripMenuItem.Checked;
            TopMost = topmostWindowToolStripMenuItem.Checked;

            // Invalidate the Client area
            Refresh();

            // Invalidate the nonclient area
            RedrawWindow(this.Handle, IntPtr.Zero, IntPtr.Zero, (RedrawWindowFlags)(0x0400/*RDW_FRAME*/ | 0x0100/*RDW_UPDATENOW*/ | 0x0001/*RDW_INVALIDATE*/));

        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            transparentToolStripMenuItem.Checked = !transparentToolStripMenuItem.Checked;
            if (transparentToolStripMenuItem.Checked)
            {
                TransparencyKey = BackColor;
            }
            else
            {
                TransparencyKey = Color.FromArgb(0, 0, 0, 0);
            }
        }

        void Overlay_Resize(object sender, System.EventArgs e)
        {
            Refresh();
        }

        bool drag = false;
        Size offset;
        void Overlay_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (drag)
            {
                this.Location = Cursor.Position + offset;
                // Invalidate();
                Refresh();
            }
        }

        void Overlay_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            drag = false;
            Refresh();
        }

        void Overlay_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            offset = new Size(this.Location);
            offset.Width -= Cursor.Position.X;
            offset.Height -= Cursor.Position.Y;
            drag = true;
            Refresh();
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topToolStripMenuItem.Checked = true;
            middleToolStripMenuItem.Checked = false;
            bottomToolStripMenuItem.Checked = false;
            Refresh();
        }

        private void middleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topToolStripMenuItem.Checked = false;
            middleToolStripMenuItem.Checked = true;
            bottomToolStripMenuItem.Checked = false;
            Refresh();
        }

        private void bottomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            topToolStripMenuItem.Checked = false;
            middleToolStripMenuItem.Checked = false;
            bottomToolStripMenuItem.Checked = true;
            Refresh();
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftToolStripMenuItem.Checked = true;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = false;
            Refresh();
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = true;
            rightToolStripMenuItem.Checked = false;
            Refresh();
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            leftToolStripMenuItem.Checked = false;
            centerToolStripMenuItem.Checked = false;
            rightToolStripMenuItem.Checked = true;
            Refresh();
        }

        void Overlay_LostFocus(object sender, System.EventArgs e)
        {
            Refresh();
        }

        void Overlay_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            parent.overlay = null;
        }

        private void foregroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = ForeColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                ForeColor = colorDialog.Color;

                // Invalidate the Client area
                Refresh();
            }
        }

        private void backgroundColourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog.Color = BackColor;
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                BackColor = colorDialog.Color;

                // Invalidate the Client area
                Refresh();
            }
        }

        private void subtitleStyleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OverlayStyle overlay = new OverlayStyle();

            overlay.ShowDialog(this);
        }
    }
}

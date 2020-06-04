/*
 * $Id$
 *
 * (C) 2006-2010 see AUTHORS
 *
 * This file is part of mplayerc.
 *
 * Mplayerc is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 3 of the License, or
 * (at your option) any later version.
 *
 * Mplayerc is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 */

// This file define commands used for "Media Player Classic - Homecinema" API. To send commands
// to mpc-hc, and receive playback notifications, first launch process with the /slave command line
// argument follow by an HWnd handle use to receive notification :
//
// ..\bin\mplayerc /slave 125421
//
// After startup, mpc-hc send a WM_COPYDATA message to host with COPYDATASTRUCT struct filled with :
//		- dwData	: CMD_CONNECT
//		- lpData	: Unicode string containing mpc-hc main window Handle
//
// To pilot mpc-hc, send WM_COPYDATA messages to Hwnd provided on connection. All messages should be
// formatted as Unicode strings. For commands or notifications with multiple parameters, values are
// separated by |
// If a string contains a |, it will be escaped with a \ so a \| is not a separator
//
// Ex : When a file is opened, mpc-hc send to host the "now playing" notification :
//		- dwData	: CMD_NOWPLAYING
//		- lpData	: title|author|description|filename|duration
//
// Ex : When a DVD is playing, use CMD_GETNOWPLAYING to get:
//		- dwData	: CMD_NOWPLAYING
//		- lpData	: dvddomain|titlenumber|numberofchapters|currentchapter|titleduration
//								dvddomains : DVD - Stopped, DVD - FirstPlay, DVD - RootMenu, DVD - TitleMenu, DVD - Title

//#pragma once

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


namespace MpcApi
{

    public enum MPC_LOADSTATE : uint
    { //typedef enum MPC_LOADSTATE {
        MLS_CLOSED,
        MLS_LOADING,
        MLS_LOADED,
        MLS_CLOSING
    } //};


    public enum MPC_PLAYSTATE : uint
    { //typedef enum MPC_PLAYSTATE {
        PS_PLAY = 0,
        PS_PAUSE = 1,
        PS_STOP = 2,
        PS_UNUSED = 3
    } //};


    //struct MPC_OSDDATA {
    //	int nMsgPos;       // screen position constant (see OSD_MESSAGEPOS constants)
    //	int nDurationMS;   // duration in milliseconds
    //	TCHAR strMsg[128]; // message to display thought OSD
    //};
    //// MPC_OSDDATA.nMsgPos constants (for host side programming):
    //typedef enum
    //{
    //    OSD_NOMESSAGE,
    //    OSD_TOPLEFT,
    //    OSD_TOPRIGHT,
    //} OSD_MESSAGEPOS;


    public enum MPCAPI_COMMAND : uint
    { //typedef enum MPCAPI_COMMAND {
        // ==== Commands from MPC to host

        // Send after connection
        // Par 1 : MPC window handle (command should be send to this HWnd)
        CMD_CONNECT = 0x50000000,

        // Send when opening or closing file
        // Par 1 : current state (see MPC_LOADSTATE enum)
        CMD_STATE = 0x50000001,

        // Send when playing, pausing or closing file
        // Par 1 : current play mode (see MPC_PLAYSTATE enum)
        CMD_PLAYMODE = 0x50000002,

        // Send after opening a new file
        // Par 1 : title
        // Par 2 : author
        // Par 3 : description
        // Par 4 : complete filename (path included)
        // Par 5 : duration in seconds
        CMD_NOWPLAYING = 0x50000003,

        // List of subtitle tracks
        // Par 1 : Subtitle track name 0
        // Par 2 : Subtitle track name 1
        // ...
        // Par n : Active subtitle track, -1 if subtitles disabled
        //
        // if no subtitle track present, returns -1
        // if no file loaded, returns -2
        CMD_LISTSUBTITLETRACKS = 0x50000004,

        // List of audio tracks
        // Par 1 : Audio track name 0
        // Par 2 : Audio track name 1
        // ...
        // Par n : Active audio track
        //
        // if no audio track present, returns -1
        // if no file loaded, returns -2
        CMD_LISTAUDIOTRACKS = 0x50000005,

        // Send current playback position in responce
        // of CMD_GETCURRENTPOSITION.
        // Par 1 : current position in seconds
        CMD_CURRENTPOSITION = 0x50000007,

        // Send the current playback position after a jump.
        // (Automatically sent after a seek event).
        // Par 1 : new playback position (in seconds).
        CMD_NOTIFYSEEK = 0x50000008,

        // Notify the end of current playback
        // (Automatically sent).
        // Par 1 : none.
        CMD_NOTIFYENDOFSTREAM = 0x50000009,

        // List of files in the playlist
        // Par 1 : file path 0
        // Par 2 : file path 1
        // ...
        // Par n : active file, -1 if no active file
        CMD_PLAYLIST = 0x50000006,


        // ==== Commands from host to MPC

        // Open new file
        // Par 1 : file path
        CMD_OPENFILE = 0xA0000000,

        // Stop playback, but keep file / playlist
        CMD_STOP = 0xA0000001,

        // Stop playback and close file / playlist
        CMD_CLOSEFILE = 0xA0000002,

        // Pause or restart playback
        CMD_PLAYPAUSE = 0xA0000003,

        // Add a new file to playlist (did not start playing)
        // Par 1 : file path
        CMD_ADDTOPLAYLIST = 0xA0001000,

        // Remove all files from playlist
        CMD_CLEARPLAYLIST = 0xA0001001,

        // Start playing playlist
        CMD_STARTPLAYLIST = 0xA0001002,

        CMD_REMOVEFROMPLAYLIST = 0xA0001003,	// TODO

        // Cue current file to specific position
        // Par 1 : new position in seconds
        CMD_SETPOSITION = 0xA0002000,

        // Set the audio delay
        // Par 1 : new audio delay in ms
        CMD_SETAUDIODELAY = 0xA0002001,

        // Set the subtitle delay
        // Par 1 : new subtitle delay in ms
        CMD_SETSUBTITLEDELAY = 0xA0002002,

        // Set the active file in the playlist
        // Par 1 : index of the active file, -1 for no file selected
        // DOESN'T WORK
        CMD_SETINDEXPLAYLIST = 0xA0002003,

        // Set the audio track
        // Par 1 : index of the audio track
        CMD_SETAUDIOTRACK = 0xA0002004,

        // Set the subtitle track
        // Par 1 : index of the subtitle track, -1 for disabling subtitles
        CMD_SETSUBTITLETRACK = 0xA0002005,

        // Ask for a list of the subtitles tracks of the file
        // return a CMD_LISTSUBTITLETRACKS
        CMD_GETSUBTITLETRACKS = 0xA0003000,

        // Ask for the current playback position,
        // see CMD_CURRENTPOSITION.
        // Par 1 : current position in seconds
        CMD_GETCURRENTPOSITION = 0xA0003004,

        // Jump forward/backward of N seconds,
        // Par 1 : seconds (negative values for backward)
        CMD_JUMPOFNSECONDS = 0xA0003005,

        // Ask for a list of the audio tracks of the file
        // return a CMD_LISTAUDIOTRACKS
        CMD_GETAUDIOTRACKS = 0xA0003001,

        // Ask for the properties of the current loaded file
        // return a CMD_NOWPLAYING
        CMD_GETNOWPLAYING = 0xA0003002,

        // Ask for the current playlist
        // return a CMD_PLAYLIST
        CMD_GETPLAYLIST = 0xA0003003,

        // Toggle FullScreen
        CMD_TOGGLEFULLSCREEN = 0xA0004000,

        // Jump forward(medium)
        CMD_JUMPFORWARDMED = 0xA0004001,

        // Jump backward(medium)
        CMD_JUMPBACKWARDMED = 0xA0004002,

        // Increase Volume
        CMD_INCREASEVOLUME = 0xA0004003,

        // Decrease volume
        CMD_DECREASEVOLUME = 0xA0004004,

        // Shader toggle
        CMD_SHADER_TOGGLE = 0xA0004005,

        // Close App
        CMD_CLOSEAPP = 0xA0004006,

        // show host defined OSD message string
        CMD_OSDSHOWMESSAGE = 0xA0005000,

    } //};


    public partial class MPCControlForm : Form
    {
        public bool VideoCurrentlyPlaying = false;
        public bool VideoCurrentlyOpen = false;
        public string VideoFileName = "";
        public int VideoDurationMs = 0;

        private int PausedPositionMs = 0;
        private int LastReportedPositionMs = 0;
        private DateTime LastReportedDateTime;
        public int CurrentPositionMs
        {
            get
            {
                if (VideoCurrentlyOpen)
                {
                    if (VideoCurrentlyPlaying && LastReportedPositionMs > 0)
                    {
                        DateTime now = DateTime.UtcNow;
                        TimeSpan diff = now.Subtract(LastReportedDateTime);
                        int diffMs = (int)diff.TotalMilliseconds;
                        return Math.Max(diffMs, 0) + LastReportedPositionMs;
                    }
                    else
                    {
                        return PausedPositionMs;
                    }
                }
                else
                {
                    return 0;
                }
            }
        }



        static private Process MediaPlayerProcess;
        static private int MediaPlayerHandle = 0;
        static private int HandleInt32 = 0;

        System.Threading.Thread GetCurrentPosThread = new System.Threading.Thread(GetCurrentPosHandler);

        public MPCControlForm()
        {
            HandleInt32 = Handle.ToInt32();

            GetCurrentPosThread.Start();
        }

        protected void ExitMPCApiApp()
        {
            // kill the thread nicely
            PollThreadQuit = true;
            GetCurrentPosEvent.Set();

            // Kill the app
            //Application.Exit();
        }

        //For use with WM_COPYDATA and COPYDATASTRUCT
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, ref COPYDATASTRUCT lParam);

        public const int WM_USER = 0x400;
        public const int WM_COPYDATA = 0x4A;

        //Used for WM_COPYDATA for string messages
        public struct COPYDATASTRUCT
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }

        public string GetMPCCommand(MPCAPI_COMMAND cmd)
        {
            string name;

            switch (cmd)
            {
                case MPCAPI_COMMAND.CMD_CONNECT:
                    name = "CMD_CONNECT";
                    break;
                case MPCAPI_COMMAND.CMD_STATE:
                    name = "CMD_STATE";
                    break;
                case MPCAPI_COMMAND.CMD_PLAYMODE:
                    name = "CMD_PLAYMODE";
                    break;
                case MPCAPI_COMMAND.CMD_NOWPLAYING:
                    name = "CMD_NOWPLAYING";
                    break;
                case MPCAPI_COMMAND.CMD_LISTSUBTITLETRACKS:
                    name = "CMD_LISTSUBTITLETRACKS";
                    break;
                case MPCAPI_COMMAND.CMD_LISTAUDIOTRACKS:
                    name = "CMD_LISTAUDIOTRACKS";
                    break;
                case MPCAPI_COMMAND.CMD_CURRENTPOSITION:
                    name = "CMD_CURRENTPOSITION";
                    break;
                case MPCAPI_COMMAND.CMD_NOTIFYSEEK:
                    name = "CMD_NOTIFYSEEK";
                    break;
                case MPCAPI_COMMAND.CMD_NOTIFYENDOFSTREAM:
                    name = "CMD_NOTIFYENDOFSTREAM";
                    break;
                case MPCAPI_COMMAND.CMD_PLAYLIST:
                    name = "CMD_PLAYLIST";
                    break;
                default:
                    name = String.Format("Unknown Command: 0x{0:X8}", (int)cmd);
                    break;
            }

            return name;
        }

        public string GetMPCCommandParamStr(MPCAPI_COMMAND cmd, string lpData)
        {
            string param;

            if (lpData == null)
            {
                param = "(none)";
            }
            else
            {
                switch (cmd)
                {
                    case MPCAPI_COMMAND.CMD_STATE:
                        MPC_LOADSTATE loadState = (MPC_LOADSTATE)int.Parse(lpData);

                        switch (loadState)
                        {
                            case MPC_LOADSTATE.MLS_CLOSED:
                                param = "MLS_CLOSED";
                                break;
                            case MPC_LOADSTATE.MLS_LOADING:
                                param = "MLS_LOADING";
                                break;
                            case MPC_LOADSTATE.MLS_LOADED:
                                param = "MLS_LOADED";
                                break;
                            case MPC_LOADSTATE.MLS_CLOSING:
                                param = "MLS_CLOSING";
                                break;
                            default:
                                param = "Unknown MPC_LOADSTATE: " + lpData;
                                break;
                        }

                        break;
                    case MPCAPI_COMMAND.CMD_PLAYMODE:
                        MPC_PLAYSTATE playState = (MPC_PLAYSTATE)int.Parse(lpData);

                        switch (playState)
                        {
                            case MPC_PLAYSTATE.PS_PLAY:
                                param = "PS_PLAY";
                                break;
                            case MPC_PLAYSTATE.PS_PAUSE:
                                param = "PS_PAUSE";
                                break;
                            case MPC_PLAYSTATE.PS_STOP:
                                param = "PS_STOP";
                                break;
                            case MPC_PLAYSTATE.PS_UNUSED:
                                param = "PS_UNUSED";
                                break;
                            default:
                                param = "Unknown MPC_PLAYSTATE: " + lpData;
                                break;
                        }

                        break;

                    default:
                        param = lpData;
                        break;
                }
            }
            return param;
        }

        protected override void WndProc(ref Message ThisMsg)
        {
            if (ThisMsg.Msg == WM_COPYDATA)
            {
                COPYDATASTRUCT mystr = new COPYDATASTRUCT();
                Type mytype = mystr.GetType();
                mystr = (COPYDATASTRUCT)ThisMsg.GetLParam(mytype);

                string msg = GetMPCCommand((MPCAPI_COMMAND)mystr.dwData);
                string param = GetMPCCommandParamStr((MPCAPI_COMMAND)mystr.dwData, mystr.lpData);

                Debug.WriteLine(msg + " " + param);

                MPCAPI_COMMAND command = (MPCAPI_COMMAND)mystr.dwData.ToInt32();

                switch (command)
                {
                    case MPCAPI_COMMAND.CMD_CONNECT:
                        MediaPlayerHandle = Convert.ToInt32(mystr.lpData);
                        NotifyConnected();
                        break;

                    case MPCAPI_COMMAND.CMD_STATE:
                        MPC_LOADSTATE loadState = (MPC_LOADSTATE)int.Parse(mystr.lpData);
                        switch (loadState)
                        {
                            case MPC_LOADSTATE.MLS_CLOSED:
                                VideoFileName = "";
                                VideoDurationMs = 0;
                                VideoCurrentlyPlaying = false;
                                VideoCurrentlyOpen = false;
                                NotifyClosed();
                                break;
                            case MPC_LOADSTATE.MLS_LOADING:
                                NotifyLoading();
                                break;
                            case MPC_LOADSTATE.MLS_LOADED:
                                VideoCurrentlyOpen = true;
                                PausedPositionMs = 0;
                                NotifyLoaded();
                                break;
                            case MPC_LOADSTATE.MLS_CLOSING:
                                VideoCurrentlyPlaying = false;
                                NotifyClosing();
                                break;
                            default:
                                break;
                        }
                        break;

                    case MPCAPI_COMMAND.CMD_PLAYMODE:
                        MPC_PLAYSTATE playState = (MPC_PLAYSTATE)int.Parse(mystr.lpData);
                        switch (playState)
                        {
                            case MPC_PLAYSTATE.PS_PLAY:
                                VideoCurrentlyPlaying = true;
                                LastReportedPositionMs = -1; // invalidate the reported position; paused position is better for now
                                ResyncTime();
                                NotifyPlay();
                                break;
                            case MPC_PLAYSTATE.PS_PAUSE:
                                PausedPositionMs = CurrentPositionMs; // set the paused position
                                VideoCurrentlyPlaying = false;
                                NotifyPause();
                                break;
                            case MPC_PLAYSTATE.PS_STOP:
                                VideoCurrentlyPlaying = false;
                                PausedPositionMs = 0;
                                NotifyStop();
                                break;
                            case MPC_PLAYSTATE.PS_UNUSED:
                                break;
                            default:
                                break;
                        }
                        break;

                    case MPCAPI_COMMAND.CMD_NOWPLAYING:
                        // Par 1 : title
                        // Par 2 : author
                        // Par 3 : description
                        // Par 4 : complete filename (path included)
                        // Par 5 : duration in seconds
                        string[] parms = mystr.lpData.Split('|');
                        int duration = Convert.ToInt32(parms[4]);
                        VideoFileName = System.IO.Path.GetFileName(parms[3]);
                        VideoDurationMs = duration * 1000;
                        NotifyNowPlaying(parms[0], parms[1], parms[2], parms[3], duration);
                        ResyncTime();
                        break;

                    case MPCAPI_COMMAND.CMD_LISTSUBTITLETRACKS:
                        break;

                    case MPCAPI_COMMAND.CMD_LISTAUDIOTRACKS:
                        break;

                    case MPCAPI_COMMAND.CMD_CURRENTPOSITION:
                    {
                        int currentPos = int.Parse(mystr.lpData) * 1000;
                        ContinueResync(currentPos);
                    }
                    break;

                    case MPCAPI_COMMAND.CMD_NOTIFYSEEK:
                    {
                        int currentPos = int.Parse(mystr.lpData) * 1000;
                        LastReportedDateTime = DateTime.UtcNow;
                        LastReportedPositionMs = currentPos;
                        PausedPositionMs = currentPos;
                        ResyncTime();
                    }
                    break;

                    case MPCAPI_COMMAND.CMD_NOTIFYENDOFSTREAM:
                        break;

                    case MPCAPI_COMMAND.CMD_PLAYLIST:
                        break;

                    default:
                        Debug.WriteLine("Unhandled Command");
                        break;

                }

                return;
            }

            base.WndProc(ref ThisMsg);
        }

        static public void SendMessageToMPC(MpcApi.MPCAPI_COMMAND command, string msg)
        {
            if (MediaPlayerHandle != 0 && MediaPlayerProcess != null && !MediaPlayerProcess.HasExited)
            {
                int result = 0;
                byte[] sarr = System.Text.Encoding.Unicode.GetBytes(msg);
                int len = sarr.Length;
                COPYDATASTRUCT cds = new COPYDATASTRUCT();
                cds.dwData = new IntPtr((int)command);
                cds.lpData = msg;
                cds.cbData = len + 1;
                result = SendMessage(MediaPlayerHandle, WM_COPYDATA, HandleInt32, ref cds);
            }
            else
            {
                MessageBox.Show("Not Connected to Media Player!\nUse File->Spawn MPC to start Media Player Classic");
            }
        }

        public void SpawnMPC()
        {
            if (MediaPlayerProcess == null || MediaPlayerProcess.HasExited)
            {
                String filename = GetMPCPath();
                String arguments = String.Format("/slave {0}", Handle);
                MediaPlayerHandle = 0;
                MediaPlayerProcess = System.Diagnostics.Process.Start(filename, arguments);
            }
            else
            {
                MessageBox.Show("Media Player Classic is already Running!");
            }
        }

        public static string GetMPCPath()
        {
            string mpcPath = "";

            try
            {
                object obj = Application.UserAppDataRegistry.GetValue("Media Player Classic Executable Path");
                if (obj != null)
                {
                    mpcPath = obj.ToString();
                }
                else
                {
                    // No key found in registry, use default.
                    // different default for 64 bit
                    bool is64Bit = false;
                    try
                    {
                        string env = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE").ToString();
                        if (env != "x86")
                        {
                            is64Bit = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                    if (is64Bit)
                    {
                        mpcPath = "C:\\Program Files (x86)\\Combined Community Codec Pack\\MPC\\mpc-hc.exe";
                    }
                    else
                    {
                        mpcPath = "C:\\Program Files\\Combined Community Codec Pack\\MPC\\mpc-hc.exe";
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return mpcPath;
        }

        public static void SetMPCPath(string mpcPath)
        {
            try
            {
                Application.UserAppDataRegistry.SetValue("Media Player Classic Executable Path", mpcPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SendCloseMPC()
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_CLOSEAPP, "");
        }

        public void SendPlayPause()
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_PLAYPAUSE, "");
        }

        public void SendStop()
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_STOP, "");
        }

        public void SendJump(int seconds)
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_JUMPOFNSECONDS, seconds.ToString());
        }

        public void SendSetPosition(int seconds)
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_SETPOSITION, seconds.ToString());
        }

        static public void SendGetCurrentPosition()
        {
            SendMessageToMPC(MPCAPI_COMMAND.CMD_GETCURRENTPOSITION, "");
        }


        // Notification methods to be overridden
        protected virtual void NotifyConnected() { }
        protected virtual void NotifyClosed() { }
        protected virtual void NotifyLoading() { }
        protected virtual void NotifyLoaded() { }
        protected virtual void NotifyClosing() { }
        protected virtual void NotifyPlay() { }
        protected virtual void NotifyPause() { }
        protected virtual void NotifyStop() { }
        protected virtual void NotifyNowPlaying(string title, string author, string description, string filename, int durationSeconds) { }


        private DateTime ResyncStartedTime;
        private int LastResyncMs = -1;
        public void ResyncTime()
        {
            // Only attempt a resync if a video is currently playing
            if (VideoCurrentlyPlaying)
            {
                LastResyncMs = -2;
                GetCurrentPosEvent.Set();
            }
        }
        void ContinueResync(int currentPos)
        {
            int adjustedPos = currentPos;
            DateTime now = DateTime.UtcNow;

            if (LastResyncMs == -1)
            {
                // Ignore: a resync wasn't started
            }
            else if (LastResyncMs == -2)
            {
                // We are just starting a resync
                LastResyncMs = currentPos;
                ResyncStartedTime = DateTime.UtcNow;
                GetCurrentPosEvent.Set();
            }
            else
            {
                if (currentPos == LastResyncMs)
                {
                    // Time is the same; continue polling
                    GetCurrentPosEvent.Set();

                    // Adjust time to a better estimate, we can add on the time that has elapsed during
                    // the resync
                    TimeSpan diff = now.Subtract(ResyncStartedTime);
                    int diffMs = (int)diff.TotalMilliseconds;
                    adjustedPos += Math.Max(diffMs, 0);
                }
                else
                {
                    // Time is different, we now have an accurate time, no need to continue
                    LastResyncMs = -1;
                }
            }

            LastReportedDateTime = now;
            LastReportedPositionMs = adjustedPos;
            PausedPositionMs = adjustedPos;
        }

        static bool PollThreadQuit = false;
        static System.Threading.AutoResetEvent GetCurrentPosEvent = new System.Threading.AutoResetEvent(false);
        static void GetCurrentPosHandler()
        {
            while (PollThreadQuit == false)
            {
                GetCurrentPosEvent.WaitOne();

                if (PollThreadQuit == false)
                {
                    // Sleep time in milliseconds; longer gives better
                    // performance but worse time resolution
                    System.Threading.Thread.Sleep(50);

                    SendGetCurrentPosition();
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace LoginMacro_Form
{
    class ProcessControl
    {
        [DllImport("user32.dll")]
        private static extern int SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
//        private static extern IntPtr ShowWindow(IntPtr hWnd, int nCmdShow);
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32")]
        public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        //        private static extern bool SetWindowPos(IntPtr windowHandle, IntPtr windowHandleInsertAfter, int x, int y, int width, int height, SetWindowPosFlag flag);

        [DllImport("user32.dll")]
        public static extern void keybd_event(uint vk, uint scan, uint flags, uint extraInfo);

        [DllImport("user32.dll")]
        internal static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        const uint WM_KEYDOWN = 0x100;
        const uint WM_SYSCOMMAND = 0x018;
        const uint SC_CLOSE = 0x053;
        const uint SHOWWINDOW = 0x0040;

        public static void ForegroundProcess(IntPtr handler, bool bMove = false)
        {
            ShowWindowAsync(handler, 1);
            SetForegroundWindow(handler);

            if (bMove)
            {
                Rect rect = new Rect();
                GetWindowRect(handler, ref rect);
                MoveWindow(handler, 0, 0, rect.right - rect.left, rect.bottom - rect.top, true);
            }
            Thread.Sleep(100);
        }

        public static void Display(int nPID, bool bMove = false)
        {
            try
            {
                Process process = new Process();
                FindProcess(ref process, nPID);

                if (process != null)
                    ForegroundProcess(process.MainWindowHandle, bMove);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        public static void MiniMizedProcess(int nPID)
        {
            Process temp = new Process();
            FindProcess(ref temp, nPID);

            ShowWindowAsync(temp.MainWindowHandle, 6);
        }
        public static void executeFile(ref Process process, string strFile)
        {
            string strFileName = null, strPath = null;
            stringParser.DivideFileFullPath(strFile, ref strPath, ref strFileName);

            process.StartInfo.FileName = strFileName;
            process.StartInfo.WorkingDirectory = strPath;
            process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
            
            process.Start();
        }
        public static bool CheckProcess(int nPID)
        {
            bool bCheck = true;
            try
            {
                Process process = System.Diagnostics.Process.GetProcessById(nPID);
                if (process == null || process.ProcessName != "winbaram")
                {
                    bCheck = false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            return bCheck;
        }

        public static bool FindProcess(ref Process process, int nPID)
        {
            try
            {
                process = System.Diagnostics.Process.GetProcessById(nPID);
            }
            catch(Exception)
            {
                return false;
            }

            return true;
        }
        public bool FindProcess(ref Process process, string strName)
        {
            Process[] processes = System.Diagnostics.Process.GetProcessesByName(strName);

            if (processes.Length > 0)
            {
                process = processes[0];
                return true;
            }
            else
                return false;
        }

        public static void keyInput(Keys InputKey, int iTime = 50)
        {
            keybd_event((byte)InputKey, 0, 0x00, 0);
            keybd_event((byte)InputKey, 0, 0x02, 0);

            Thread.Sleep(iTime);
        }
        public static void KillProcess(int nPID)
        {
            try
            {
                Process process = System.Diagnostics.Process.GetProcessById(nPID);
                process.Kill();
            }
            catch(Exception)
            {

            }
        }
    }
}

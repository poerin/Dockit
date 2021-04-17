using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Dockit
{
    internal class WindowsInfoHelper
    {

        private const int GWL_EXSTYLE = -20;
        [DllImport("user32.dll", EntryPoint = "GetDesktopWindow", CharSet = CharSet.Auto, SetLastError = true)]
        static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        private static extern uint GetWindowLong(IntPtr hwnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int EnumWindows(EnumWindowsProc ewp, int lParam);
        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        [DllImport("user32.dll")]
        public static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool IsZoomed(IntPtr hWnd);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);
        [DllImport("kernel32.dll")]
        private static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);
        [DllImport("Psapi.dll", EntryPoint = "GetModuleFileNameEx")]
        private static extern uint GetModuleFileNameEx(IntPtr handle, IntPtr hModule, [Out] StringBuilder lpszFileName, uint nSize);
        [DllImport("kernel32.dll", EntryPoint = "QueryFullProcessImageNameW", CallingConvention = CallingConvention.StdCall, CharSet = CharSet.Unicode)]
        private static extern int QueryFullProcessImageName(IntPtr hProcess, UInt32 flags, char[] exeName, ref UInt32 nameLen);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr GetParent(IntPtr hWnd);
        private static IList<WindowInfo> windows = new List<WindowInfo>();
        private delegate bool EnumWindowsProc(IntPtr handle, int param);
        private static IntPtr hDesktop = GetDesktopWindow();

        internal static string GetWindowTitle(IntPtr handle)
        {
            StringBuilder strTitle = new StringBuilder(256);
            GetWindowText(handle, strTitle, 256);
            return strTitle.ToString();
        }

        internal static string GetWindowClass(IntPtr handle)
        {
            StringBuilder sbWindowClass = new StringBuilder(256);
            GetClassName(handle, sbWindowClass, sbWindowClass.Capacity);
            return sbWindowClass.ToString();
        }

        internal static string GetFilePath(IntPtr handle)
        {
            GetWindowThreadProcessId(handle, out int pid);
            IntPtr hProcess = OpenProcess(0x0400 | 0x0010, false, pid);
            StringBuilder sbFileName = new StringBuilder(256);
            if (GetModuleFileNameEx(hProcess, IntPtr.Zero, sbFileName, (uint)sbFileName.Capacity) != 0)
            {
                return sbFileName.ToString();
            }
            else
            {
                char[] buf = new char[65535];
                UInt32 len = 65535;
                QueryFullProcessImageName(hProcess, 0, buf, ref len);
                string exeName = new string(buf, 0, (int)len);
                return string.Concat(buf).Replace("\0", "");
            }
        }

        internal static bool IsVisible(IntPtr handle)
        {
            string windowExtendStyle = Convert.ToString(GetWindowLong(handle, GWL_EXSTYLE), 2);
            return (IsWindowVisible(handle) && !(windowExtendStyle.Length > 5 && (windowExtendStyle[windowExtendStyle.Length - 6] == '1')));
        }

        internal static bool IsTopMost(IntPtr handle)
        {
            string windowExtendStyle = Convert.ToString(GetWindowLong(handle, GWL_EXSTYLE), 2);
            return (windowExtendStyle.Length > 3 && (windowExtendStyle[windowExtendStyle.Length - 4] == '1'));
        }

        internal static void GetTopWindow(ref IntPtr handle)
        {
            bool isWindow = false;

            while (!isWindow)
            {
                IntPtr parent = GetParent(handle);
                if (parent != IntPtr.Zero)
                {
                    handle = parent;
                }
                else
                {
                    isWindow = true;
                }
            }
        }


        public class WindowInfo
        {
            private IntPtr handle;
            public IntPtr Handle
            {
                get
                {
                    return handle;
                }
                set
                {
                    handle = value;
                }
            }

            private string windowTitle;
            public string WindowTitle
            {
                get
                {
                    return windowTitle;
                }
                set
                {
                    windowTitle = value;
                }
            }

            private string windowClass;
            public string WindowClass
            {
                get
                {
                    return windowClass;
                }
                set
                {
                    windowClass = value;
                }
            }

            private string filePath;
            public string FilePath
            {
                get
                {
                    return filePath;
                }
                set
                {
                    filePath = value;
                }
            }

            private bool isMinimzed;
            public bool IsMinimzed
            {
                get
                {
                    return isMinimzed;
                }
                set
                {
                    isMinimzed = value;
                }
            }

            private bool isMaximized;
            public bool IsMaximized
            {
                get
                {
                    return isMaximized;
                }
                set
                {
                    isMaximized = value;
                }
            }

            private bool isVisible;
            public bool IsVisible
            {
                get
                {
                    return isVisible;
                }
                set
                {
                    isVisible = value;
                }
            }

            public WindowInfo(IntPtr handle)
            {
                this.handle = handle;
                windowTitle = GetWindowTitle(handle);
                windowClass = GetWindowClass(handle);
                filePath = GetFilePath(handle);
                isMinimzed = IsIconic(handle);
                isMaximized = IsZoomed(handle);
                isVisible = IsVisible(handle);
            }

        }

        private static bool WindowsProc(IntPtr handle, int param)
        {
            GetTopWindow(ref handle);

            foreach (WindowInfo window in windows)
            {
                if (window.Handle == handle)
                {
                    return true;
                }
            }

            if (!IsVisible(handle) || IsIconic(handle) || IsTopMost(handle) || GetWindowClass(handle) == "ApplicationFrameWindow" || GetWindowClass(handle) == "Windows.UI.Core.CoreWindow" || handle == hDesktop)
            {
                return true;
            }

            windows.Add(new WindowInfo(handle));

            return true;

        }

        public static IList<WindowInfo> GetVisibleWindowsInfo()
        {
            windows.Clear();
            EnumWindowsProc eunmWindows = new EnumWindowsProc(WindowsProc);
            EnumWindows(eunmWindows, 0);
            return windows;
        }

    }
}

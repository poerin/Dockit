using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Dockit
{
    internal static class Dockit
    {

        #region 鼠标钩子
        #region 鼠标钩子API

        private enum WM_MOUSE : int
        {
            /// 鼠标开始
            WM_MOUSEFIRST = 0x200,
            /// 鼠标移动
            WM_MOUSEMOVE = 0x200,
            /// 左键按下
            WM_LBUTTONDOWN = 0x201,
            /// 左键释放
            WM_LBUTTONUP = 0x202,
            /// 左键双击
            WM_LBUTTONDBLCLK = 0x203,
            /// 右键按下
            WM_RBUTTONDOWN = 0x204,
            /// 右键释放
            WM_RBUTTONUP = 0x205,
            /// 右键双击
            WM_RBUTTONDBLCLK = 0x206,
            /// 中键按下
            WM_MBUTTONDOWN = 0x207,
            /// 中键释放
            WM_MBUTTONUP = 0x208,
            /// 中键双击
            WM_MBUTTONDBLCLK = 0x209,
            /// 滚轮滚动
            WM_MOUSEWHEEL = 0x020A
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct MouseHookStruct
        {
            public POINT Point;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public UInt32 ExtraInfo;
        }

        private delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern bool UnhookWindowsHookEx(int idHook);
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        private static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);

        #endregion

        public class MouseHook
        {
            private const int WH_MOUSE_LL = 14;
            private Point point;
            private int hHook;
            private HookProc hProc;

            public MouseHook()
            {
                point = new Point();
            }

            public int SetHook()
            {
                hProc = new HookProc(MouseHookProc);
                hHook = SetWindowsHookEx(WH_MOUSE_LL, hProc, IntPtr.Zero, 0);
                return hHook;
            }

            public void UnHook()
            {
                UnhookWindowsHookEx(hHook);
            }

            private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
            {
                MouseHookStruct mouseHookStruct = (MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseHookStruct));
                if (nCode < 0)
                {
                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                }
                else
                {
                    point = new Point(mouseHookStruct.Point.X, mouseHookStruct.Point.Y);
                    switch ((WM_MOUSE)wParam)
                    {
                        case WM_MOUSE.WM_MOUSEMOVE:
                            {
                                var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, 0);
                                MouseMoveEvent(this, e);
                                break;
                            }
                        case WM_MOUSE.WM_LBUTTONDOWN:
                            {
                                var e = new MouseEventArgs(MouseButtons.Left, 0, point.X, point.Y, 0);
                                MouseDownEvent(this, e);
                                break;
                            }
                        case WM_MOUSE.WM_LBUTTONUP:
                            {
                                var e = new MouseEventArgs(MouseButtons.Left, 0, point.X, point.Y, 0);
                                MouseUpEvent(this, e);
                                break;
                            }
                        case WM_MOUSE.WM_MOUSEWHEEL:
                            {
                                var e = new MouseEventArgs(MouseButtons.None, 0, point.X, point.Y, (short)((mouseHookStruct.MouseData >> 16) & 0xffff));
                                MouseWheelEvent(this, e);
                                if (shallDock)
                                {
                                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                                }
                                break;
                            }
                        case WM_MOUSE.WM_MBUTTONDOWN:
                        case WM_MOUSE.WM_RBUTTONDOWN:
                            {
                                if (shallDock)
                                {
                                    shallDock = false;
                                    canDock = false;
                                    shadow.ClearShadow();
                                }
                                enable = false;
                                break;
                            }
                        case WM_MOUSE.WM_MBUTTONUP:
                        case WM_MOUSE.WM_RBUTTONUP:
                            {
                                enable = true;
                                break;
                            }
                    }
                    return CallNextHookEx(hHook, nCode, wParam, lParam);
                }
            }

            public delegate void MouseMoveHandler(object sender, MouseEventArgs e);
            public event MouseMoveHandler MouseMoveEvent;
            public delegate void MouseDownHandler(object sender, MouseEventArgs e);
            public event MouseDownHandler MouseDownEvent;
            public delegate void MouseUpHandler(object sender, MouseEventArgs e);
            public event MouseUpHandler MouseUpEvent;
            public delegate void MouseWheelHandler(object sender, MouseEventArgs e);
            public event MouseUpHandler MouseWheelEvent;
        }

        private static MouseHook mouseHook;
        #endregion

        #region Windows API
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        const int DWMWA_EXTENDED_FRAME_BOUNDS = 9;
        [DllImport("dwmapi.dll")]
        static extern int DwmGetWindowAttribute(IntPtr hwnd, int dwAttribute, out Rect pvAttribute, int cbAttribute);
        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point point);
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);
        [DllImport("user32.dll")]
        private extern static IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);
        [DllImport("user32.dll")]
        private extern static IntPtr GetDesktopWindow();
        #endregion


        private static NotifyIcon ntfDockit;
        private static ContextMenuStrip cmsDockit;
        private static ToolStripMenuItem tsmDock;
        private static ToolStripMenuItem tsmFilter;
        private static ToolStripMenuItem tsmExit;
        internal static Dock dock;
        internal static Filter filter;
        internal static Shadow shadow;

        internal static XmlDocument xdSetting;
        internal static XmlNode xnRoot;
        internal static XmlElement xeDocks;
        internal static XmlElement xeFilters;


        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #region 读取XML
            xdSetting = new XmlDocument();
            try
            {
                xdSetting.Load(Application.StartupPath + @"\configure.xml");
            }
            catch
            {
                xnRoot = xdSetting.CreateNode(XmlNodeType.Element, "Dockit", "");
                xeDocks = xdSetting.CreateElement("Docks");
                xeFilters = xdSetting.CreateElement("Filters");
                xnRoot.AppendChild(xeDocks);
                xnRoot.AppendChild(xeFilters);
                xdSetting.AppendChild(xnRoot);
                xdSetting.Save(Application.StartupPath + @"\configure.xml");
            }
            xnRoot = xdSetting.SelectSingleNode("Dockit");
            xeDocks = (XmlElement)xnRoot.SelectSingleNode("Docks");
            xeFilters = (XmlElement)xnRoot.SelectSingleNode("Filters");
            #endregion

            #region 控件
            dock = new Dock();
            filter = new Filter();
            shadow = new Shadow();
            ntfDockit = new NotifyIcon();
            cmsDockit = new ContextMenuStrip();
            tsmDock = new ToolStripMenuItem();
            tsmFilter = new ToolStripMenuItem();
            tsmExit = new ToolStripMenuItem();

            dock.Icon = Properties.Resources.Dockit;
            filter.Icon = Properties.Resources.Dockit;

            #region Notify
            cmsDockit.SuspendLayout();

            ntfDockit.ContextMenuStrip = cmsDockit;
            ntfDockit.Icon = Properties.Resources.Dockit;
            ntfDockit.Text = "Dockit";
            ntfDockit.Visible = true;

            cmsDockit.Items.AddRange(new ToolStripItem[] {
            tsmDock,
            tsmFilter,
            tsmExit});
            cmsDockit.Name = "cmsDockit";
            cmsDockit.Size = new Size(153, 92);

            tsmDock.Name = "tsmDock";
            tsmDock.Size = new Size(152, 22);
            tsmDock.Text = "停靠规则";
            tsmDock.Click += new EventHandler(tsmDock_Click);

            tsmFilter.Name = "tsmFiltrate";
            tsmFilter.Size = new Size(152, 22);
            tsmFilter.Text = "过滤清单";
            tsmFilter.Click += tsmFiltrate_Click;

            tsmExit.Name = "tsmExit";
            tsmExit.Size = new Size(152, 22);
            tsmExit.Text = "退出程序";
            tsmExit.Click += new EventHandler(tsmExit_Click);

            cmsDockit.ResumeLayout(false);
            #endregion
            #endregion

            #region 鼠标钩子事件
            mouseHook = new MouseHook();
            mouseHook.SetHook();
            mouseHook.MouseMoveEvent += MouseHook_MouseMoveEvent;
            mouseHook.MouseDownEvent += MouseHook_MouseDownEvent;
            mouseHook.MouseUpEvent += MouseHook_MouseUpEvent;
            mouseHook.MouseWheelEvent += MouseHook_MouseWheelEvent;
            #endregion

            Application.Run();
        }

        private static bool canDock = false;
        private static bool shallDock = false;
        private static bool shallSmartDock = false;
        private static bool enable = true;
        private static Point SmartDockPoint = new Point();
        private static int lastSmartDockWindowIndex = 0;
        private static IntPtr hLastSmartDockWindow;
        private static IntPtr hCurrentWindow;
        private static IntPtr hForegroundWindow;
        private static Rect rectCurrentWindow;
        private static Rectangle rectDockArea;
        private static Rectangle rectWorkingArea;
        private static IList<WindowsInfoHelper.WindowInfo> windows = WindowsInfoHelper.GetVisibleWindowsInfo();
        private static List<Rectangle> rectSmartDocks = new List<Rectangle>();
        private static List<RectangleF> lastAllRemainRegionScans = new List<RectangleF>();
        private static List<IntPtr> topWindows = new List<IntPtr>();
        private static List<IntPtr> lastTopWindows = new List<IntPtr>();
        private static readonly Graphics graphics = Graphics.FromHdc(GetDCEx(GetDesktopWindow(), IntPtr.Zero, 0x403));
        private static readonly System.Drawing.Drawing2D.Matrix matrix = new System.Drawing.Drawing2D.Matrix();

        private static Rectangle ConvertRealRect(int top, int bottom, int left, int right)
        {
            int width = rectWorkingArea.Width;
            int height = rectWorkingArea.Height;
            int x = rectWorkingArea.X;
            int y = rectWorkingArea.Y;

            if ((top == bottom) && (left == right))
            {
                return new Rectangle(width * left / 100 + x - 3, height * top / 100 + y - 3, 6, 6);
            }
            else if (top == bottom)
            {
                return new Rectangle(width * left / 100 + x, height * top / 100 + y - 2, width * (right - left) / 100, 4);
            }
            else if (left == right)
            {
                return new Rectangle(width * left / 100 + x - 2, height * top / 100 + y, 4, height * (bottom - top) / 100);
            }

            return new Rectangle(width * left / 100 + x, height * top / 100 + y, width * (right - left) / 100, height * (bottom - top) / 100);
        }

        private static bool IsEntirelyCovered(IntPtr handle)
        {
            GetWindowRect(handle, out Rect rect);
            Rectangle rectWindow = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);

            if (rectWindow.Width == 0 || rectWindow.Height == 0)
            {
                return false;
            }

            Region region = new Region(rectWindow);

            for (int i = 0; i < windows.Count - 1; i++)
            {
                if (windows[i].Handle == handle)
                {
                    region.Dispose();
                    return false;
                }

                GetWindowRect(windows[i].Handle, out rect);
                Rectangle rectangle = new Rectangle(rect.Left, rect.Top, rect.Right - rect.Left, rect.Bottom - rect.Top);
                region.Exclude(rectangle);

                if (region.IsEmpty(graphics))
                {
                    region.Dispose();
                    return true;
                }

            }

            region.Dispose();
            return false;
        }

        private static Region GetRemainRegion(IntPtr handle, Rectangle thisWorkingArea)
        {
            Region region = new Region(thisWorkingArea);

            DwmGetWindowAttribute(handle, DWMWA_EXTENDED_FRAME_BOUNDS, out Rect rectFrame, Marshal.SizeOf(typeof(Rect)));
            GetWindowRect(handle, out Rect rectWindow);
            int shadowWidth = ((rectWindow.Right - rectWindow.Left) - (rectFrame.Right - rectFrame.Left)) / 2;
            int shadowHeight = ((rectWindow.Bottom - rectWindow.Top) - (rectFrame.Bottom - rectFrame.Top));

            Rectangle rectangle = new Rectangle(rectWindow.Left + shadowWidth, rectWindow.Top, rectWindow.Right - rectWindow.Left - shadowWidth * 2, rectWindow.Bottom - rectWindow.Top - shadowHeight);
            region.Exclude(rectangle);
            return region;
        }

        private static Region GetAllRemainRegion(IntPtr handle, Rectangle thisWorkingArea)
        {
            Region region = new Region(thisWorkingArea);

            for (int i = 0; i < windows.Count - 1; i++)
            {

                if (windows[i].Handle == handle)
                {
                    continue;
                }

                DwmGetWindowAttribute(windows[i].Handle, DWMWA_EXTENDED_FRAME_BOUNDS, out Rect rectFrame, Marshal.SizeOf(typeof(Rect)));
                GetWindowRect(windows[i].Handle, out Rect rectWindow);
                int shadowWidth = ((rectWindow.Right - rectWindow.Left) - (rectFrame.Right - rectFrame.Left)) / 2;
                int shadowHeight = ((rectWindow.Bottom - rectWindow.Top) - (rectFrame.Bottom - rectFrame.Top));

                Rectangle rectangle = new Rectangle(rectWindow.Left + shadowWidth, rectWindow.Top, rectWindow.Right - rectWindow.Left - shadowWidth * 2, rectWindow.Bottom - rectWindow.Top - shadowHeight);
                if (rectangle.Width * rectangle.Height != 0 && rectangle.Width * rectangle.Height < thisWorkingArea.Width * thisWorkingArea.Height)
                {
                    region.Exclude(rectangle);
                }

            }

            return region;
        }

        private static bool IsListChanged<T>(List<T> newList, List<T> oldList)
        {
            if (newList.Count != oldList.Count)
            {
                return true;
            }

            foreach (object newObject in newList)
            {
                bool hasThis = false;

                foreach (object oldObject in oldList)
                {
                    if (object.Equals(newObject, oldObject))
                    {
                        hasThis = true;
                    }
                }

                if (!hasThis)
                {
                    return true;
                }

            }

            foreach (object oldObject in oldList)
            {
                bool hasThis = false;

                foreach (object newObject in newList)
                {
                    if (object.Equals(newObject, oldObject))
                    {
                        hasThis = true;
                    }
                }

                if (!hasThis)
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HasLargePiece(RectangleF newRect, RectangleF oldRect)
        {
            if ((newRect.X == oldRect.X && newRect.Width == oldRect.Width) && oldRect.Contains(newRect))
            {
                return true;
            }

            if ((newRect.Y == oldRect.Y && newRect.Height == oldRect.Height) && oldRect.Contains(newRect))
            {
                return true;
            }

            return false;
        }

        private static void MouseHook_MouseDownEvent(object sender, MouseEventArgs e)
        {
            hCurrentWindow = WindowFromPoint(e.Location);
            WindowsInfoHelper.GetTopWindow(ref hCurrentWindow);
            GetWindowRect(hCurrentWindow, out rectCurrentWindow);

            WindowsInfoHelper.WindowInfo currentWindow = new WindowsInfoHelper.WindowInfo(hCurrentWindow);

            foreach (XmlElement xe in xeFilters)
            {
                string windowClass = ((XmlElement)xe.SelectSingleNode("WindowClass")).GetAttribute("Text");
                string windowTitle = ((XmlElement)xe.SelectSingleNode("WindowTitle")).GetAttribute("Text");
                string windowTitleLogic = ((XmlElement)xe.SelectSingleNode("WindowTitle")).GetAttribute("Logic");
                string filePath = ((XmlElement)xe.SelectSingleNode("FilePath")).GetAttribute("Text");

                if (currentWindow.WindowClass == windowClass && string.Equals(currentWindow.FilePath, filePath, StringComparison.OrdinalIgnoreCase) && ((windowTitleLogic == "Include" && currentWindow.WindowTitle.Contains(windowTitle)) || (windowTitleLogic == "Equal" && currentWindow.WindowTitle == windowTitle)))
                {
                    shallDock = false;
                    return;
                }
            }

            if (hCurrentWindow == dock.Handle || hCurrentWindow == filter.Handle)
            {
                shallDock = false;
                return;
            }

            shallDock = true;
        }

        private static void MouseHook_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            if (shallSmartDock)
            {
                if ((e.X - SmartDockPoint.X) * (e.X - SmartDockPoint.X) + (e.Y - SmartDockPoint.Y) * (e.Y - SmartDockPoint.Y) > 512)
                {
                    shallSmartDock = false;
                }
            }
            else
            {
                rectWorkingArea = Screen.FromPoint(e.Location).WorkingArea;

                int x = e.X < rectWorkingArea.X ? rectWorkingArea.X : e.X;
                int y = e.Y < rectWorkingArea.Y ? rectWorkingArea.Y : e.Y;
                x = x > rectWorkingArea.Width + rectWorkingArea.X ? rectWorkingArea.Width + rectWorkingArea.X : x;
                y = y > rectWorkingArea.Height + rectWorkingArea.Y ? rectWorkingArea.Height + rectWorkingArea.Y : y;

                hForegroundWindow = GetForegroundWindow();
                WindowsInfoHelper.GetTopWindow(ref hForegroundWindow);
                GetWindowRect(hForegroundWindow, out Rect rectForegroundWindow);

                if (shallDock && ((hCurrentWindow == hForegroundWindow) && ((rectCurrentWindow.Left != rectForegroundWindow.Left || rectCurrentWindow.Top != rectForegroundWindow.Top) && (rectCurrentWindow.Bottom - rectCurrentWindow.Top == rectForegroundWindow.Bottom - rectForegroundWindow.Top && rectCurrentWindow.Right - rectCurrentWindow.Left == rectForegroundWindow.Right - rectForegroundWindow.Left))))
                {
                    foreach (XmlElement xe in xeDocks)
                    {
                        XmlElement xeTrigger = (XmlElement)xe.SelectSingleNode("Trigger");
                        XmlElement xeDock = (XmlElement)xe.SelectSingleNode("Dock");

                        Rectangle rectTrigger = ConvertRealRect(Convert.ToInt32(xeTrigger.GetAttribute("Top")), Convert.ToInt32(xeTrigger.GetAttribute("Bottom")), Convert.ToInt32(xeTrigger.GetAttribute("Left")), Convert.ToInt32(xeTrigger.GetAttribute("Right")));

                        if (rectTrigger.Contains(x, y))
                        {
                            canDock = true;
                            rectDockArea = ConvertRealRect((xeDock.GetAttribute("Top") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Top")) : 0), (xeDock.GetAttribute("Bottom") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Bottom")) : 100), (xeDock.GetAttribute("Left") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Left")) : 0), (xeDock.GetAttribute("Right") != "-" ? Convert.ToInt32(xeDock.GetAttribute("Right")) : 100));

                            if (xeDock.GetAttribute("Top") == "-")
                            {
                                rectDockArea = new Rectangle(rectDockArea.X, rectForegroundWindow.Top, rectDockArea.Width, rectDockArea.Height - rectForegroundWindow.Top + rectWorkingArea.Y);
                            }

                            if (xeDock.GetAttribute("Bottom") == "-")
                            {
                                rectDockArea = new Rectangle(rectDockArea.X, rectDockArea.Y, rectDockArea.Width, rectForegroundWindow.Bottom - rectDockArea.Y);
                            }

                            if (xeDock.GetAttribute("Left") == "-")
                            {
                                rectDockArea = new Rectangle(rectForegroundWindow.Left, rectDockArea.Y, rectDockArea.Width - rectForegroundWindow.Left + rectWorkingArea.X, rectDockArea.Height);
                            }

                            if (xeDock.GetAttribute("Right") == "-")
                            {
                                rectDockArea = new Rectangle(rectDockArea.X, rectDockArea.Y, rectForegroundWindow.Right - rectDockArea.X, rectDockArea.Height);
                            }

                            shadow.FillShadow(rectDockArea);
                            return;
                        }

                    }
                }

                canDock = false;
                shadow.ClearShadow();
            }
        }

        private static void MouseHook_MouseUpEvent(object sender, MouseEventArgs e)
        {
            if (filter.Spying)
            {
                filter.picSpy.Image = Properties.Resources.Spy.ToBitmap();
                shadow.Cursor = Cursors.Default;
                filter.Spying = false;

                IntPtr handle = WindowFromPoint(e.Location);
                WindowsInfoHelper.GetTopWindow(ref handle);
                filter.FillInfo(handle);
            }

            if (canDock)
            {
                hForegroundWindow = GetForegroundWindow();

                DwmGetWindowAttribute(hForegroundWindow, DWMWA_EXTENDED_FRAME_BOUNDS, out Rect rectFrame, Marshal.SizeOf(typeof(Rect)));
                GetWindowRect(hForegroundWindow, out Rect rectWindow);
                int shadowWidth = ((rectWindow.Right - rectWindow.Left) - (rectFrame.Right - rectFrame.Left)) / 2;
                int shadowHeight = ((rectWindow.Bottom - rectWindow.Top) - (rectFrame.Bottom - rectFrame.Top));


                Task.Run(() => { Thread.Sleep(100); SetWindowPos(hForegroundWindow, IntPtr.Zero, rectDockArea.X - shadowWidth, rectDockArea.Y, rectDockArea.Width + shadowWidth * 2, rectDockArea.Height + shadowHeight, 0); });

                shadow.ClearShadow();
            }

            shallDock = false;
        }

        private static void MouseHook_MouseWheelEvent(object sender, MouseEventArgs e)
        {
            if (shallDock && enable)
            {
                shallSmartDock = true;
                SmartDockPoint = e.Location;
                rectWorkingArea = Screen.FromPoint(SmartDockPoint).WorkingArea;
                hForegroundWindow = GetForegroundWindow();
                windows = WindowsInfoHelper.GetVisibleWindowsInfo();
                Region allRemainRegion = GetAllRemainRegion(hForegroundWindow, rectWorkingArea);
                List<RectangleF> allRemainRegionScans = new List<RectangleF>(allRemainRegion.GetRegionScans(matrix));
                topWindows.Clear();

                foreach (WindowsInfoHelper.WindowInfo item in windows)
                {
                    if (!IsEntirelyCovered(item.Handle) && item.Handle != hForegroundWindow)
                    {
                        topWindows.Add(item.Handle);
                    }
                }

                bool isChanged = false;

                if (IsListChanged(allRemainRegionScans, lastAllRemainRegionScans) || IsListChanged(topWindows, lastTopWindows))
                {
                    isChanged = true;
                    lastAllRemainRegionScans = new List<RectangleF>(allRemainRegionScans.ToArray());
                    lastTopWindows = new List<IntPtr>(topWindows.ToArray());
                }

                if (hLastSmartDockWindow != hForegroundWindow || isChanged)
                {
                    hLastSmartDockWindow = hForegroundWindow;
                    lastSmartDockWindowIndex = 0;
                    rectSmartDocks.Clear();

                    foreach (RectangleF item in allRemainRegionScans)
                    {
                        if (!(item.X == rectWorkingArea.X && item.Y == rectWorkingArea.Y && item.Width == rectWorkingArea.Width && item.Height == rectWorkingArea.Height))
                        {
                            Region rContainer = allRemainRegion.Clone();
                            rContainer.Intersect(new RectangleF(item.X, rectWorkingArea.Y, item.Width, rectWorkingArea.Height));

                            foreach (RectangleF rectPiece in rContainer.GetRegionScans(matrix))
                            {
                                if (rectPiece.Width < 200 || rectPiece.Height < 200)
                                {
                                    continue;
                                }

                                rectSmartDocks.Add(new Rectangle((int)rectPiece.X, (int)rectPiece.Y, (int)rectPiece.Width, (int)rectPiece.Height));
                            }
                        }
                    }

                    for (int i = rectSmartDocks.Count - 1; i > -1; i--)
                    {
                        for (int j = rectSmartDocks.Count - 1; j > -1; j--)
                        {
                            if (HasLargePiece(rectSmartDocks[i], rectSmartDocks[j]) && i != j)
                            {
                                rectSmartDocks.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    List<Rectangle> listTopRectSmartDock = new List<Rectangle>();

                    foreach (IntPtr item in topWindows)
                    {
                        Region remainRegion = GetRemainRegion(item, rectWorkingArea);

                        foreach (RectangleF scans in remainRegion.GetRegionScans(matrix))
                        {
                            if (!(scans.X == rectWorkingArea.X && scans.Y == rectWorkingArea.Y && scans.Width == rectWorkingArea.Width && scans.Height == rectWorkingArea.Height))
                            {
                                Region rContainer = remainRegion.Clone();
                                rContainer.Intersect(new RectangleF(scans.X, rectWorkingArea.Y, scans.Width, rectWorkingArea.Height));

                                foreach (RectangleF rectPiece in rContainer.GetRegionScans(matrix))
                                {
                                    if (rectPiece.Width < 200 || rectPiece.Height < 200)
                                    {
                                        continue;
                                    }

                                    listTopRectSmartDock.Add(new Rectangle((int)rectPiece.X, (int)rectPiece.Y, (int)rectPiece.Width, (int)rectPiece.Height));
                                }
                            }
                        }
                    }

                    for (int i = listTopRectSmartDock.Count - 1; i > -1; i--)
                    {
                        for (int j = listTopRectSmartDock.Count - 1; j > -1; j--)
                        {
                            if (HasLargePiece(listTopRectSmartDock[i], listTopRectSmartDock[j]) && i != j)
                            {
                                listTopRectSmartDock.RemoveAt(i);
                                break;
                            }
                        }
                    }

                    foreach (Rectangle item in listTopRectSmartDock)
                    {
                        bool hasThis = false;
                        foreach (Rectangle smartDock in rectSmartDocks)
                        {
                            if (smartDock.X == item.X && smartDock.Y == item.Y && smartDock.Width == item.Width && smartDock.Height == item.Height)
                            {
                                hasThis = true;
                            }
                        }

                        if (!hasThis)
                        {
                            rectSmartDocks.Add(item);
                        }

                    }

                    rectSmartDocks.Insert(0, rectWorkingArea);

                }

                if (e.Delta < 0)
                {
                    lastSmartDockWindowIndex++;
                    if (lastSmartDockWindowIndex == rectSmartDocks.Count)
                    {
                        lastSmartDockWindowIndex = 0;
                    }
                }
                else
                {
                    lastSmartDockWindowIndex--;
                    if (lastSmartDockWindowIndex == -1)
                    {
                        lastSmartDockWindowIndex = rectSmartDocks.Count - 1;
                    }
                }

                shadow.FillShadow(rectSmartDocks[lastSmartDockWindowIndex]);
                rectDockArea = rectSmartDocks[lastSmartDockWindowIndex];
                canDock = true;

            }
        }

        #region Notify事件
        private static void tsmDock_Click(object sender, EventArgs e)
        {
            filter.Hide();
            dock.Show();
            dock.HideTriggerPreview();
            dock.HideDockPreview();
        }

        private static void tsmFiltrate_Click(object sender, EventArgs e)
        {
            dock.Hide();
            filter.Show();
        }

        private static void tsmExit_Click(object sender, EventArgs e)
        {
            mouseHook.UnHook();
            Application.Exit();
        }
        #endregion


    }
}

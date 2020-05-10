using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SwitchToDesktopFromSlideshow.Win32
{
    internal class API
    {
        [DllImport("user32", SetLastError = true)]
        internal static extern int RegisterHotKey(IntPtr hWnd, int id, KeyModifiers modifier, Keys key);

        [DllImport("user32", SetLastError = true)]
        internal static extern int UnregisterHotKey(IntPtr hWnd, int id);

        internal delegate bool EnumWindowsDelegate(IntPtr hWnd, IntPtr lparam);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal extern static bool EnumWindows(EnumWindowsDelegate callBack, IntPtr lparam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetWindowText(IntPtr hWnd, StringBuilder windowText, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern int GetClassName(IntPtr hWnd, StringBuilder className, int maxCount);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr FindWindow(string className, string windowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern int ShowWindow(IntPtr hWnd, ShowWindows showWindows);

        [DllImport("user32")]
        internal static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hwnd, out Rect rect);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern IntPtr GetDesktopWindow();

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPos(IntPtr hWnd, IntPtr insertAfter, int x, int y, int cx, int cy, SetWindowPosFlags flags);

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool SetWindowPos(IntPtr hWnd, InsertAfters insertAfter, int x, int y, int cx, int cy, SetWindowPosFlags flags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        internal static extern long SetDisplayConfig(uint numPathArrayElements, IntPtr pathArray, uint numModeArrayElements, IntPtr modeArray, SetDisplayConfigFlags flags);
    }
}

using System.Runtime.InteropServices;

namespace SwitchToDesktopFromSlideshow.Win32
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect
    {
        public int Left;
        public int Top;
        public int Right;
        public int Bottom;
    }
}

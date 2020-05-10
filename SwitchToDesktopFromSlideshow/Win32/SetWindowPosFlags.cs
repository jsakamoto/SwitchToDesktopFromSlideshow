using System;

namespace SwitchToDesktopFromSlideshow.Win32
{
    [Flags]
    public enum SetWindowPosFlags : int
    {
        NoSize = 0x0001,
        NoMove = 0x0002,
        NoZOrder = 0x0004,
        ShowWindow = 0x0040,
        AsyncWindowPos = 0x4000,
    }
}

using System;

namespace SwitchToDesktopFromSlideshow.Win32
{
    [Flags]
    public enum KeyModifiers : int
    {
        Alt = 0x01,
        Ctrl = 0x02,
        Shift = 0x04,
        Win = 0x08,
    }
}

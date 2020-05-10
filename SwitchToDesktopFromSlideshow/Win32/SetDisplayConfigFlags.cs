using System;

namespace SwitchToDesktopFromSlideshow.Win32
{
    [Flags]
    internal enum SetDisplayConfigFlags : UInt32
    {
        TopologyInternal = 0x00000001,
        TopologyClone = 0x00000002,
        TopologyExtend = 0x00000004,
        TopologyExternal = 0x00000008,
        Apply = 0x00000080
    }
}

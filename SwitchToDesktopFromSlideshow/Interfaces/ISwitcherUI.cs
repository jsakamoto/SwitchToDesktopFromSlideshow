using System.Drawing;

namespace SwitchToDesktopFromSlideshow.Interfaces
{
    public interface ISwitcherUI
    {
        void OnBeforeSwitch(Rectangle bounds);

        void OnAfterSwitch();
    }
}

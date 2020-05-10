using System;
using SwitchToDesktopFromSlideshow.Events;

namespace SwitchToDesktopFromSlideshow.Interfaces
{
    public interface ISwitcherSettingsProvider
    {
        event EventHandler<SwitcherSettingsChangedEventArgs> SwitcherSettingsChanged;

        SwitcherSettings GetSwitcherSettings();
    }
}

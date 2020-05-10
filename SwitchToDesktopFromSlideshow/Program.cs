using System;
using System.Threading;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Events;
using SwitchToDesktopFromSlideshow.Forms;
using SwitchToDesktopFromSlideshow.Properties;

namespace SwitchToDesktopFromSlideshow
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using var mutex = new Mutex(true, "6e97c1c3-3344-4f0f-b3dc-5f7b8f43be84", out var createdNew);
            if (!createdNew) { mutex.Close(); return; }
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var switcherSettings = LoadSwitcherSettings();
                using var mainForm = new MainForm(switcherSettings);
                using var screenMaskForm = new ScreenMaskForm();
                screenMaskForm.Show();

                using var switcher = new Switcher(mainForm, mainForm, screenMaskForm);
                mainForm.SwitcherSettingsChanged += MainForm_SwitcherSettingsChanged;

                Application.Run();

                mainForm.SwitcherSettingsChanged -= MainForm_SwitcherSettingsChanged;
            }
            finally
            {
                mutex.ReleaseMutex();
                mutex.Close();
            }
        }

        private static SwitcherSettings LoadSwitcherSettings()
        {
            var settings = Settings.Default;
            if (settings._UpgradeRequired)
            {
                settings.Upgrade();
                settings._UpgradeRequired = false;
                settings.Save();
            }
            var switcherSettings = settings.ToSwitcherSettings();
            return switcherSettings;
        }

        private static void MainForm_SwitcherSettingsChanged(object sender, SwitcherSettingsChangedEventArgs args)
        {
            var settings = Settings.Default;
            args.NewSettings.Apply(settings);
            settings.Save();
        }
    }
}

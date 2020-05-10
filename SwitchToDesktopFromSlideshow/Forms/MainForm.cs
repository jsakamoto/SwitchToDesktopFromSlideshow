using System;
using System.Drawing;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Events;
using SwitchToDesktopFromSlideshow.Interfaces;
using SwitchToDesktopFromSlideshow.Win32;

namespace SwitchToDesktopFromSlideshow.Forms
{
    public partial class MainForm : Form, IHotkeyEventProvier, ISwitcherSettingsProvider
    {
        private SwitcherSettings SwitcherSettings { get; set; }

        private ConfigurationForm ConfigurationFormShowing { get; set; }

        private ScreenMaskForm ScreenMaskFormShowing { get; set; }

        public MainForm()
        {
            InitializeComponent();
        }

        public MainForm(SwitcherSettings switcherSettings)
        {
            InitializeComponent();
            SwitcherSettings = switcherSettings;

            UpdateNotifyIconText();
        }

        private void UpdateNotifyIconText()
        {
            var text = $"{this.Text}\n({this.SwitcherSettings.GetHotkeyText()})";
            if (text.Length >= 64)
                text = text.Substring(0, 60) + "...";

            this.NotifyIcon.Text = text;
        }

        public event EventHandler HotkeyPressed;

        public event EventHandler<SwitcherSettingsChangedEventArgs> SwitcherSettingsChanged;

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WinMessages.HotKey)
            {
                HotkeyPressed?.Invoke(this, EventArgs.Empty);
            }
        }

        public void RegisterHotKey(int id, KeyModifiers keyModifiers, Keys key)
        {
            API.RegisterHotKey(this.Handle, id, keyModifiers, key);
        }

        public void UnregisterHotKey(int id)
        {
            API.UnregisterHotKey(this.Handle, id);
        }

        private void ConfigurationMenuItem_Click(object sender, EventArgs e)
        {
            var menuItem = sender as ToolStripMenuItem;
            var location = this.PointToScreen(menuItem.Owner.Bounds.Location);
            ShowConfigurationDialog(location);
        }

        private void NotifyIcon_DoubleClick(object sender, EventArgs e)
        {
            this.ShowConfigurationDialog(Cursor.Position);
        }

        private void ShowConfigurationDialog(Point location)
        {
            if (this.ConfigurationFormShowing != null)
            {
                this.ConfigurationFormShowing.Activate();
                return;
            }
            var newSettings = this.SwitcherSettings.Clone();
            try
            {
                this.ConfigurationFormShowing = new ConfigurationForm(newSettings, location);
                var result = ConfigurationFormShowing.ShowDialog();

                if (result == DialogResult.OK)
                {
                    this.SwitcherSettings = newSettings;
                    this.UpdateNotifyIconText();
                    this.SwitcherSettingsChanged?.Invoke(this, new SwitcherSettingsChangedEventArgs(newSettings));
                }
            }
            finally
            {
                this.ConfigurationFormShowing?.Dispose();
                this.ConfigurationFormShowing = null;
            }
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public SwitcherSettings GetSwitcherSettings()
        {
            return this.SwitcherSettings;
        }
    }
}

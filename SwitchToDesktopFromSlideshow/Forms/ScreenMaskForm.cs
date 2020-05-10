using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using SwitchToDesktopFromSlideshow.Interfaces;

namespace SwitchToDesktopFromSlideshow.Forms
{
    public partial class ScreenMaskForm : Form, ISwitcherUI
    {
        private const int Step = 16;
        private const int Interval = 30;

        public ScreenMaskForm()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                this.Opacity = 0.0;
                this.Visible = false;
                this.SetBounds(0, 0, 0, 0);
            }
        }

        public void OnBeforeSwitch(Rectangle bounds)
        {
            this.Opacity = 0.0;
            this.Visible = false;
            var targetScreen = Screen.FromPoint(bounds.Location);
            this.Bounds = targetScreen.Bounds;
            this.Visible = true;

            FadeIn();
        }

        public void OnAfterSwitch()
        {
            this.FadeOut();
            this.Visible = false;
        }

        public void FadeIn() => FadeInOut(op => op);

        public void FadeOut() => FadeInOut(op => 1.0 - op);

        private void FadeInOut(Func<double, double> f)
        {
            for (var i = 0; i < Step; i++)
            {
                this.Opacity = 0.8 * f.Invoke(((double)i) / (Step - 1));
                Thread.Sleep(Interval);
            }
        }
    }
}

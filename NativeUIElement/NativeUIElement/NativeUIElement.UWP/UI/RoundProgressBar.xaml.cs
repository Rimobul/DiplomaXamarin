using System;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace NativeUIElement.UWP.UI
{
    public sealed partial class RoundProgressBar : UserControl
    {
        private double progress;

        public RoundProgressBar() : this(1.0)
        {
        }

        public RoundProgressBar(double max)
        {
            this.InitializeComponent();
            Max = max;
            PathOutline.StartPoint = new Point(TheSegment.Size.Width, 0);
            ArcOutline.Size = new Size(TheSegment.Size.Width, TheSegment.Size.Height);
            ArcOutline.Point = new Point(TheSegment.Size.Width - 0.05, 0);
            ThePathFigure.StartPoint = new Point(TheSegment.Size.Width, 0);
        }

        public Color ProgressColor
        {
            get { return (ThePath.Stroke as SolidColorBrush)?.Color ?? new Color(); }
            set { ThePath.Stroke = new SolidColorBrush(value); }
        }
        public Color ProgressBackgroundColor
        {
            get { return (ThePathBackground.Stroke as SolidColorBrush)?.Color ?? new Color(); }
            set { ThePathBackground.Stroke = new SolidColorBrush(value); }
        }

        public double Max { get; private set; }

        public double Progress
        {
            get { return progress; }
            set
            {
                if (progress != value)
                {
                    if (value >= Max)
                    {
                        progress = Max - 0.0001;
                    }
                    else
                    {
                        progress = value;
                    }

                    double angle = (360 * progress) * Math.PI / 180;
                    double x = Math.Sin(angle) * TheSegment.Size.Width + TheSegment.Size.Width;
                    double y = (Math.Cos(angle) * TheSegment.Size.Width - TheSegment.Size.Width) * -1;

                    IAsyncAction TheTask = CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.High, () =>
                        {
                            TheSegment.IsLargeArc = angle >= Math.PI;
                            TheSegment.Point = new Point(x, y);
                        });
                }
            }
        }

    }

}

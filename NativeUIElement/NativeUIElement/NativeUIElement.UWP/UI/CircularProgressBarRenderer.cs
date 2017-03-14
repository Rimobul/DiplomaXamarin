using System.ComponentModel;
using NativeUIElement.UI;
using NativeUIElement.UWP.UI;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(CircularProgressBar), typeof(CircularProgressBarRenderer))]
namespace NativeUIElement.UWP.UI
{
    public class CircularProgressBarRenderer
        : ViewRenderer<CircularProgressBar, RoundProgressBar>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            var progress = new RoundProgressBar(Element.Max)
            {
                Progress = Element.Progress,
                ProgressColor = Element.ProgressColor.ToWindows(),
                ProgressBackgroundColor = Element.ProgressBackgroundColor.ToWindows()
            };

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Element == null || this.Control == null)
                return;

            if (e.PropertyName == CircularProgressBar.ProgressProperty.PropertyName)
            {
                Control.Progress = Element.Progress;
            }
        }
    }
}

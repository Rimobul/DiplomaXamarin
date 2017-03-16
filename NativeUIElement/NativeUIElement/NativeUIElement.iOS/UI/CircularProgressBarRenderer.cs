using System.ComponentModel;
using NativeUIElement.iOS.UI;
using NativeUIElement.UI;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CircularProgressBar), typeof(CircularProgressBarRenderer))]
namespace NativeUIElement.iOS.UI
{
    public class CircularProgressBarRenderer
        : ViewRenderer<CircularProgressBar, CircleGraph>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            var progress = new CircleGraph(new CoreGraphics.CGRect(1, 1, 1, 1), Element.Max)
            {
                Progress = Element.Progress,
                ProgressColor = Element.ProgressColor.ToUIColor(),
                ProgressBackgroundColor = Element.ProgressBackgroundColor.ToUIColor()
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

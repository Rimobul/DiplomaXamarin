using NativeUIElement.UI;
using Xamarin.Forms;
using NativeUIElement.Droid.UI;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using com.refractored.monodroidtoolkit;

[assembly: ExportRenderer(typeof(CircularProgressBar), typeof(CircularProgressBarRenderer))]
namespace NativeUIElement.Droid.UI
{
    public class CircularProgressBarRenderer 
        : ViewRenderer<CircularProgressBar, HoloCircularProgressBar>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CircularProgressBar> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || this.Element == null)
                return;

            var progress = new HoloCircularProgressBar(Forms.Context)
            {
                Max = Element.Max,
                Progress = Element.Progress,
                ProgressColor = Element.ProgressColor.ToAndroid(),
                ProgressBackgroundColor = Element.ProgressBackgroundColor.ToAndroid()
            };

            SetNativeControl(progress);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (this.Element == null || this.Control == null)
                return;

            //if(e.PropertyName == CircularProgressBar.ProgressProperty.PropertyName)
            //{
            //    Control.Progress = Element.Progress;
            //}
        }
    }
}
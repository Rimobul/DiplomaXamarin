using Xamarin.Forms;

namespace NativeUIElement.UI
{
    public class CircularProgressBar : View
    {
        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create("ProgressColor", typeof(Color), typeof(CircularProgressBar), defaultValue: Color.FromRgba(1, 0, 0, 1), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty ProgressBackgroundColorProperty =
            BindableProperty.Create("ProgressBackgroundColor", typeof(Color), typeof(CircularProgressBar), defaultValue: Color.FromRgba(0, 0, 0, 1), defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty MaxProperty =
            BindableProperty.Create("MaxProperty", typeof(float), typeof(CircularProgressBar), defaultValue: 100f, defaultBindingMode: BindingMode.TwoWay);
        public static readonly BindableProperty ProgressProperty =
                    BindableProperty.Create("Progress", typeof(float), typeof(CircularProgressBar), defaultValue: 50f, defaultBindingMode: BindingMode.TwoWay);

        public Color ProgressColor
        {
            get { return (Color)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }
        public Color ProgressBackgroundColor
        {
            get { return (Color)GetValue(ProgressBackgroundColorProperty); }
            set { SetValue(ProgressBackgroundColorProperty, value); }
        }

        public float Max
        {
            get { return (float)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public float Progress
        {
            get { return (float)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }
    }
}

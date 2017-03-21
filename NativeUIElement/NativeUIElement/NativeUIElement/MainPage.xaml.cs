using NativeUIElement.ViewModels;
using Xamarin.Forms;

namespace NativeUIElement
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var viewModel = new RandomViewModel();
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}

using CameraAndLocation.ViewModels;
using Xamarin.Forms;

namespace CameraAndLocation
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            var viewModel = new CameraLocationViewModel();
            viewModel.AlertDisplayer = DisplayAlert;
            BindingContext = viewModel;
            InitializeComponent();
        }
    }
}

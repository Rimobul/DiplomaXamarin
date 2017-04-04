using TabletLayout.ViewModels;
using Xamarin.Forms;

namespace TabletLayout.Views
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            BindingContext = new MenuViewModel();
            InitializeComponent();
        }
    }
}

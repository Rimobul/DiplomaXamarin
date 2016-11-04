
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class HelloPage : ContentPage
    {
        public HelloPage()
        {
            InitializeComponent();
            BindingContext = new ViewModel();
        }
    }
}

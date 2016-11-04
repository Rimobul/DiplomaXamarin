using PersistentStorage.ViewModels;
using Xamarin.Forms;

namespace PersistentStorage
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            BindingContext = new SampleRecordsList();
            InitializeComponent();
        }
    }
}

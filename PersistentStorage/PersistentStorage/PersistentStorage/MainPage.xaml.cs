using PersistentStorage.Models;
using PersistentStorage.ViewModels;
using Xamarin.Forms;

namespace PersistentStorage
{
    public partial class MainPage : ContentPage
    {
        private SampleRecordsList viewModel;

        public MainPage()
        {
            viewModel = new SampleRecordsList();
            BindingContext = viewModel;
            InitializeComponent();
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;
            Device.BeginInvokeOnMainThread(() => viewModel.SelectForeignRecord((e.SelectedItem as SampleRecord)));
        }
    }
}

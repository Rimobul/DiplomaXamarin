using System;
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
            listView.ItemSelected += OnItemSelected;
        }

        public event Action<ViewModels.MenuItem> ItemChanged;

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as ViewModels.MenuItem;
            if (item != null)
            {
                ItemChanged?.Invoke(item);
                listView.SelectedItem = null;
            }
        }
    }
}

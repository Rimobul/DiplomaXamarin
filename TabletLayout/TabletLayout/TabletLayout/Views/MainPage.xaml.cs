using System;
using Xamarin.Forms;

namespace TabletLayout.Views
{
    public partial class MainPage : MasterDetailPage
    {
        public MainPage()
        {
            InitializeComponent();
            if (Device.Idiom == TargetIdiom.Phone)
            {
                this.MasterBehavior = MasterBehavior.Popover;
            }
            else
            {
                this.MasterBehavior = MasterBehavior.Split;
            }
            menuPage.ItemChanged += OnItemChanged;
        }

        private void OnItemChanged(ViewModels.MenuItem item)
        {
            Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
            if (Device.Idiom == TargetIdiom.Phone)
            {
                IsPresented = false;
            }
        }
    }
}

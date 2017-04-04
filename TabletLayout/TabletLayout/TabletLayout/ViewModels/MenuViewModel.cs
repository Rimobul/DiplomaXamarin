using System;
using System.Collections.Generic;
using TabletLayout.Views;
using Xamarin.Forms;

namespace TabletLayout.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        private List<MenuItem> items;

        public MenuViewModel()
        {
            items = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Common page",
                    TargetType = typeof(CommonPage)
                },
                new MenuItem
                {
                    Title = "Customized page",
                    TargetType = GetCustomizedPage()
                }
            };
        }

        public List<MenuItem> MenuItems { get { return items; } }

        private Type GetCustomizedPage()
        {
            if (Device.Idiom == TargetIdiom.Phone)
            {
                return typeof(PhonePage);
            }
            else
            {
                return typeof(TabletPage);
            }
        }
    }
}

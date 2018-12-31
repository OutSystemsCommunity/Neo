using DiveLog.Models;
using DiveLog.Utility;

using System.Collections.Generic;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.Dives, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            DebugLogger.Log();

            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Dives:
                        MenuPages.Add(id, new NavigationPage(new ItemsPage()));
                        break;
                    case (int)MenuItemType.Settings:
                        MenuPages.Add(id, new NavigationPage(new SettingsPage()));
                        break;
                    case (int)MenuItemType.Logout:
                        Application.Current.MainPage = new LoginPage();
                        return;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                {
                    await Task.Delay(100);
                }
                IsPresented = false;
            }
        }
    }
}
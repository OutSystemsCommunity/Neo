using System;

using DiveLog.Utility;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            DebugLogger.Log();

            InitializeComponent();
        }

        private void Toggle_Theme_Clicked(object sender, EventArgs e) 
        {
            bool isDark;
            if (ToggleButton.BackgroundColor.Equals(Color.White))
            {
                isDark = false;
            }
            else
            {
                isDark = true;
            }
            DisplayAlert("Alert", "Theme toggled " 
            	// + "to " + (isDark ? "dark" : "light") + ". This change will show after you've closed and reopened the app."
                , "OK");
            //TODO Persist this across sessions
        }
    }
}

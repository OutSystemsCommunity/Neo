using System.Threading.Tasks;
using System.Windows.Input;

using DiveLog.Utility;
using DiveLog.Views;

using Xamarin.Forms;

namespace DiveLog.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand ToggleThemeCommand { get; }

        public SettingsViewModel()
        {
            DebugLogger.Log();

            Title = "Settings";

            ToggleThemeCommand = new Command(() =>
            {
                if (IsDark)
                {
                    Application.Current.Properties[Constants.THEME_KEY] = Constants.LIGHT_THEME_VALUE;
                    IsDark = false;
                }
                else
                {
                    Application.Current.Properties[Constants.THEME_KEY] = Constants.DARK_THEME_VALUE;
                    IsDark = true;
                }

                Task.Run(async () => await Application.Current.SavePropertiesAsync());

                DebugLogger.Log($"Toggled to {(IsDark ? Constants.DARK_THEME_VALUE : Constants.LIGHT_THEME_VALUE)}", "ToggleThemeCommand");

                //TODO how to throw up an alert? this doesn't do it:
                Task.Run(async () => await Application.Current.MainPage.DisplayAlert("Alert", "Theme toggled", "OK"));

                //TODO how to reload the page? this doesn't work quite right:
                //Application.Current.MainPage = new SettingsPage();
            });
        }
    }
}

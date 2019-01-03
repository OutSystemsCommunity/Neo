using System.Threading.Tasks;
using System.Windows.Input;

using DiveLog.Utility;

using Xamarin.Forms;

namespace DiveLog.ViewModels
{
    public class SettingsViewModel : BaseViewModel
    {
        public ICommand ToggleThemeCommand { get; }
        public Color LocalButtonBackgroundColor { get { return ButtonBackgroundColor; } }
        public Color LocalButtonTextColor { get { return ButtonTextColor; } }

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

                DebugLogger.Log($"Theme toggled to {(IsDark ? Constants.DARK_THEME_VALUE : Constants.LIGHT_THEME_VALUE)}", "ToggleThemeCommand");
                //TODO Persist this across sessions
            });
        }
    }
}

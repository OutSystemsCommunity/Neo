using System;
using System.Windows.Input;
using DiveLog.Utility;
using DiveLog.Views;
using Xamarin.Forms;

namespace DiveLog.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            DebugLogger.Log();

            Title = "Login title";
            LoginCommand = new Command(() => 
            {
                Application.Current.MainPage = new MainPage();
            });

            SetTheme();
        }
    }
}

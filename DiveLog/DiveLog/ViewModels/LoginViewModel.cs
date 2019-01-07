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
                //TODO Put validation and authentication here
                Application.Current.MainPage = new MainPage();
            });

            SetTheme();
        }
    }
}

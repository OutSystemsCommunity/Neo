using DiveLog.Utility;
using DiveLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel viewModel;

        public static Color LocalBackgroundColor;
        public static Color LocalTextColor;
        public static Color LocalButtonBackgroundColor;
        public static Color LocalButtonTextColor;

        public LoginPage()
        {
            DebugLogger.Log();

            InitializeComponent();
            BindingContext = viewModel = new LoginViewModel();

            LocalBackgroundColor = viewModel.BackgroundColor;
            LocalTextColor = viewModel.TextColor;
            LocalButtonBackgroundColor = viewModel.ButtonBackgroundColor;
            LocalButtonTextColor = viewModel.ButtonTextColor;

        }
    }
}

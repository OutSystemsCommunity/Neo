using DiveLog.Utility;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            DebugLogger.Log();

            InitializeComponent();
        }
    }
}

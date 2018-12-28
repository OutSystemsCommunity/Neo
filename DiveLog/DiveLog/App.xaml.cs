using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DiveLog.Views;
using DiveLog.Utility;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DiveLog
{
    public partial class App : Application
    {

        public App()
        {
            DebugLogger.Log();

            InitializeComponent();

            MainPage = new LoginPage(); 
        }

        protected override void OnStart()
        {
            DebugLogger.Log();
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            DebugLogger.Log();
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            DebugLogger.Log();
            // Handle when your app resumes
        }
    }
}

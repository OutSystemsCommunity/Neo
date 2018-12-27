using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DiveLog
{
    public partial class App : Application
    {

        public App()
        {
            DebugLogger.Log();

            //old
            //InitializeComponent();
            //MainPage = new MainPage();

            //new
            // The root page of your application
            var layout = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "Welcome to DiveLog!"
                    }
                }
            };

            MainPage = new ContentPage
            {
                Content = layout
            };

            Button button = new Button
            {
                Text = "Create a new Dive Log"
            };

            button.Clicked += async (s, e) => {
                await MainPage.DisplayAlert("Alert", "This feature is still under construction", "OK");
            };

            layout.Children.Add(button);
        }

        protected override void OnStart()
        {
            DebugLogger.Log();
            //Debug.WriteLine(MethodBase.GetCurrentMethod().Name);
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

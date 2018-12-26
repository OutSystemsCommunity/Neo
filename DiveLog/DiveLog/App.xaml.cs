using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DiveLog
{
    public partial class App : Application
    {
        public App()
        {
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
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}

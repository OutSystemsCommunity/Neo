using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.ViewModels;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DivesPage : ContentPage
    {

        DivesViewModel viewModel;

        public DivesPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            BindingContext = viewModel = new DivesViewModel();
            //Content.BackgroundColor = viewModel.BackgroundColor;
            //BackgroundColor = viewModel.BackgroundColor;
        }

        async void OnDiveSelected(object sender, SelectedItemChangedEventArgs args)
        {
            DebugLogger.Log();
            var dive = args.SelectedItem as Dive;
            if (dive == null)
            {
                DebugLogger.Log("Dive is null");
                return;
            }
            await Navigation.PushAsync(new DiveDetailPage(new DiveDetailViewModel(dive)));

            // Manually deselect item.
            DivesListView.SelectedItem = null;
        }

        async void AddDive_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();
            await Navigation.PushModalAsync(new NavigationPage(new NewDivePage()));
        }

        protected override void OnAppearing()
        {
            DebugLogger.Log();
            base.OnAppearing();

            if (viewModel.Dives.Count == 0)
            {
                viewModel.LoadDivesCommand.Execute(null);
            }
        }
    }
}
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.ViewModels;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {

        ItemsViewModel viewModel;

        public ItemsPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            BindingContext = viewModel = new ItemsViewModel();
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            DebugLogger.Log();
            var dive = args.SelectedItem as Dive;
            if (dive == null)
            {
                return;
            }
            await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(dive)));

            // Manually deselect item.
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();
            await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override void OnAppearing()
        {
            DebugLogger.Log();
            base.OnAppearing();

            if (viewModel.Dives.Count == 0)
            {
                viewModel.LoadItemsCommand.Execute(null);
            }
        }
    }
}
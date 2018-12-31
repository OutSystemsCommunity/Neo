using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.ViewModels;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            DebugLogger.Log();

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            var dive = new Dive
            {
                Text = "Item 1",
                Description = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(dive);
            BindingContext = viewModel;
        }
    }
}
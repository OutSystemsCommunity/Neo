using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewItemPage : ContentPage
    {
        public Dive Item { get; set; }

        public NewItemPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            Item = new Dive
            {
                Text = "Dive name",
                Description = "Dive description"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();

            MessagingCenter.Send(this, "AddItem", Item);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();

            await Navigation.PopModalAsync();
        }
    }
}
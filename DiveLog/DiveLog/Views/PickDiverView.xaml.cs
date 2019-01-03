using System;
using System.Collections.Generic;
using DiveLog.Utility;
using DiveLog.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickDiverView : ContentPage
    {
        PickDiverViewModel viewModel;

        public PickDiverView()
        {
            DebugLogger.Log();

            InitializeComponent();

            BindingContext = viewModel = new PickDiverViewModel();
        }


        async void SaveDivers_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();

            //await Navigation.PushModalAsync(new NavigationPage(new NewDivePage()));
        }
    }
}

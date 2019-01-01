using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.ViewModels;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DiveDetailPage : ContentPage
    {
        DiveDetailViewModel viewModel;

        public DiveDetailPage(DiveDetailViewModel viewModel)
        {
            DebugLogger.Log();

            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public DiveDetailPage()
        {
            DebugLogger.Log();

            InitializeComponent();

            var dive = new Dive();

            viewModel = new DiveDetailViewModel(dive);
            BindingContext = viewModel;
        }
    }
}
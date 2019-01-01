using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using DiveLog.Models;
using DiveLog.Utility;

namespace DiveLog.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewDivePage : ContentPage
    {
        public Dive Dive { get; set; }
        public DateTime MAX_DATE { get { return Constants.MAX_DATE(); } }
        public DateTime MIN_DATE { get { return Constants.MIN_DATE(); } }
        public string[] Locations { get { return Constants.Locations(); } }

        public NewDivePage()
        {
            DebugLogger.Log();

            InitializeComponent();

            Dive = new Dive
            {
                Id = Guid.NewGuid().ToString(),
                Location = "CW7",
                Date = DateTime.Now,
                DPIC = "Stacey",
                Tender = "David",
                Mode = "SCUBA"
            };

            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();

            MessagingCenter.Send(this, "AddDive", Dive);
            await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            DebugLogger.Log();

            await Navigation.PopModalAsync();
        }
    }
}
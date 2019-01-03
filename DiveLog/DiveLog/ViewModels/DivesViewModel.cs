using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using DiveLog.Models;
using DiveLog.Views;
using DiveLog.Utility;

namespace DiveLog.ViewModels
{
    public class DivesViewModel : BaseViewModel
    {
        public ObservableCollection<Dive> Dives { get; set; }
        public Command LoadDivesCommand { get; set; }

        public DivesViewModel()
        {
            DebugLogger.Log();

            Title = "Dives";
            Dives = new ObservableCollection<Dive>();
            LoadDivesCommand = new Command(async () => await ExecuteLoadDivesCommand());

            MessagingCenter.Subscribe<NewDivePage, Dive>(this, "AddDive", async (obj, dive) =>
            {
                var newDive = dive as Dive;
                Dives.Add(newDive);
                await DataStore.AddDiveAsync(newDive);
                //SetTheme();
            });
            SetTheme();

        }

        async Task ExecuteLoadDivesCommand()
        {
            DebugLogger.Log();

            if (IsBusy)
            {
                DebugLogger.Log("Is busy");
                return;
            }
            IsBusy = true;

            try
            {
                Dives.Clear();
                DebugLogger.Log($"TextColor: {TextColor}");
                var dives = await DataStore.GetDivesAsync(true);
                foreach (var dive in dives)
                {
                    Dives.Add(dive);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                SetTheme();
                IsBusy = false;
            }
        }
    }
}
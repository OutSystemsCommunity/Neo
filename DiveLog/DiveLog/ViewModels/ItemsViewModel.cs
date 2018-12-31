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
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Dive> Dives { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            DebugLogger.Log();

            Title = "Dives";
            Dives = new ObservableCollection<Dive>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Dive>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Dive;
                Dives.Add(newItem);
                await DataStore.AddItemAsync(newItem);
                //SetTheme();
            });
            SetTheme();

        }

        async Task ExecuteLoadItemsCommand()
        {
            DebugLogger.Log();

            if (IsBusy)
            {
                return;
            }
            IsBusy = true;

            try
            {
                Dives.Clear();
                Debug.WriteLine($"TextColor: {TextColor}");
                var items = await DataStore.GetItemsAsync(true);
                foreach (var item in items)
                {
                    Dives.Add(item);
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
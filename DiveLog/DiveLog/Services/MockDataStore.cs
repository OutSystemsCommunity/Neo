using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DiveLog.Models;
using DiveLog.Utility;

namespace DiveLog.Services
{
    public class MockDataStore : IDataStore<Dive>
    {
        List<Dive> dives;

        public MockDataStore()
        {
            DebugLogger.Log();

            dives = new List<Dive>();
            var mockItems = new List<Dive>
            {
                new Dive { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Dive 1", 
                    Description="Dive 1 description",
                    Location="OV",
                    Date=DateTime.Today,
                    DPIC="Alice",
                    Tender="Bob",
                    Mode="SCUBA",
                },
                new Dive { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Dive 2", 
                    Description="Dive 2 description",
                    Location="CW7",
                    Date=DateTime.Today,
                    DPIC="Bob",
                    Tender="Charlie",
                    Mode="SCUBA",
                },
                new Dive { 
                    Id = Guid.NewGuid().ToString(), 
                    Text = "Dive 3", 
                    Description="Dive 3 description",
                    Location="OV",
                    Date=DateTime.Today,
                    DPIC="Charlie",
                    Tender="Alice",
                    Mode="SurfaceSupplied",
                },
            };

            foreach (var dive in mockItems)
            {
                dives.Add(dive);
            }
        }

        public async Task<bool> AddItemAsync(Dive dive)
        {
            DebugLogger.Log();

            dives.Add(dive);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Dive dive)
        {
            DebugLogger.Log();

            var oldDive = dives.Where((Dive arg) => arg.Id == dive.Id).FirstOrDefault();
            dives.Remove(oldDive);
            dives.Add(dive);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            DebugLogger.Log();

            var oldDive = dives.Where((Dive arg) => arg.Id == id).FirstOrDefault();
            dives.Remove(oldDive);

            return await Task.FromResult(true);
        }

        public async Task<Dive> GetItemAsync(string id)
        {
            DebugLogger.Log();

            return await Task.FromResult(dives.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Dive>> GetItemsAsync(bool forceRefresh = false)
        {
            DebugLogger.Log();

            return await Task.FromResult(dives);
        }
    }
}
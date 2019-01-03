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
                    Location=Location.OV,
                    Date=DateTime.Now,
                    DPIC="Alice",
                    Tender="Bob",
                    Mode=Mode.SCUBA,
                },
                new Dive { 
                    Id = Guid.NewGuid().ToString(), 
                    Location=Location.CW7,
                    Date=DateTime.Now,
                    DPIC="Bob",
                    Tender="Charlie",
                    Mode=Mode.Snorkel,
                },
                new Dive { 
                    Id = Guid.NewGuid().ToString(), 
                    Location=Location.OV,
                    Date=DateTime.Now,
                    DPIC="Charlie",
                    Tender="Alice",
                    Mode=Mode.SurfaceSupplied,
                },
            };

            foreach (var dive in mockItems)
            {
                dives.Add(dive);
            }
        }

        public async Task<bool> AddDiveAsync(Dive dive)
        {
            DebugLogger.Log();

            dives.Add(dive);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateDiveAsync(Dive dive)
        {
            DebugLogger.Log();

            var oldDive = dives.Where((Dive arg) => arg.Id == dive.Id).FirstOrDefault();
            dives.Remove(oldDive);
            dives.Add(dive);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteDiveAsync(string id)
        {
            DebugLogger.Log();

            var oldDive = dives.Where((Dive arg) => arg.Id == id).FirstOrDefault();
            dives.Remove(oldDive);

            return await Task.FromResult(true);
        }

        public async Task<Dive> GetDiveAsync(string id)
        {
            DebugLogger.Log();

            return await Task.FromResult(dives.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Dive>> GetDivesAsync(bool forceRefresh = false)
        {
            DebugLogger.Log();

            return await Task.FromResult(dives);
        }
    }
}
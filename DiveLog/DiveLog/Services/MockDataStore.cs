using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DiveLog.Models;
using DiveLog.Utility;

namespace DiveLog.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        List<Item> items;

        public MockDataStore()
        {
            DebugLogger.Log();

            items = new List<Item>();
            var mockItems = new List<Item>
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "Dive 1", Description="Dive 1 description" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Dive 2", Description="Dive 2 description" },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Dive 3", Description="Dive 3 description" },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            DebugLogger.Log();

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            DebugLogger.Log();

            var oldItem = items.Where((Item arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            DebugLogger.Log();

            var oldItem = items.Where((Item arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            DebugLogger.Log();

            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            DebugLogger.Log();

            return await Task.FromResult(items);
        }
    }
}
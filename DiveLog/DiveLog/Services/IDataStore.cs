using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiveLog.Services
{
    public interface IDataStore<T>
    {
        Task<bool> AddDiveAsync(T item);
        Task<bool> UpdateDiveAsync(T item);
        Task<bool> DeleteDiveAsync(string id);
        Task<T> GetDiveAsync(string id);
        Task<IEnumerable<T>> GetDivesAsync(bool forceRefresh = false);
    }
}

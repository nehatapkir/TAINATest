using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TAINATest.Repository
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAllItems();
   //     Task AddItem(T item);
        Task UpdateItem(T item);
        Task<T> GetItemById(long id);
         void AddItem(T item);
    }
}

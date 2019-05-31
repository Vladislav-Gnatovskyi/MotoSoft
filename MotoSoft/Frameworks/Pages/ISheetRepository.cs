using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Frameworks.Pages
{
    public interface ISheetRepository<T>
    {
        event EventHandler DataChanged;
        Task<IList<T>> GetSheetAsync();
        bool AddNewItem(T item);
    }
}

using System.Collections.Generic;

namespace MotoSoft.Frameworks.Pages
{
    public interface ISheetUpdate<T>
    {
        bool AddItem(T item);
        bool EditItem(T newItem, T oldItem);
        T Remove(T item, bool isDelete = true);
        void Save(IList<T> sheet);
    }
}

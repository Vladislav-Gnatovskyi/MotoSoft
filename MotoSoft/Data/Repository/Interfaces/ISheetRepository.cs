using System.Collections.Generic;
namespace MotoSoft.Data.Repository.Interfaces
{
    public interface ISheetRepository<T>
    {
        IList<T> GetSheet();
        void Save(IList<T> sheet);
    }
}

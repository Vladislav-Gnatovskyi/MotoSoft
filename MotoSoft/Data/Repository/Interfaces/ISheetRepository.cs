using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.Interfaces
{
    public interface ISheetRepository<T>
    {
        IList<T> GetSheet();
        Task<IList<T>> GetSheetAsync();
    }
}

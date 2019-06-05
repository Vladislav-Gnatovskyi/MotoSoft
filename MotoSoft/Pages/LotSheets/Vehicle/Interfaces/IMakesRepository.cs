using MotoSoft.Pages.LotSheets.Vehicle.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MotoSoft.Pages.LotSheets.Vehicle.Interfaces
{
    public interface IMakesRepository
    {
        event EventHandler DataChanged;
        Task<IList<Make>> GetMakesAsync();
        IList<Make> GetMakes();
        IList<Model> GetModels(string make, ETypeVehicle type);
        sbyte AddMake(Make item);
        sbyte AddModel(Make make, Model model);
        sbyte AddModel(Make make, string modelName);
        void Save(IList<Make> sheet);
    }
}

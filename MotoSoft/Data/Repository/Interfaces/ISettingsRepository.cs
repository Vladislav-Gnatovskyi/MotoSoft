
using MotoSoft.Data.Models;

namespace MotoSoft.Data.Repository.Interfaces
{
    public interface ISettingsRepository
    {
        SettingsModel Load();
        void Save(SettingsModel model);
    }
}
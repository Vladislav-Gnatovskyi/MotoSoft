namespace MotoSoft.Models
{
    public interface ISettingsRepository
    {
        SettingsModel Load();
        void Save(SettingsModel model);
    }
}
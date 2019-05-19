namespace MotoSoft.Pages.Settings
{
    public interface ISettingsRepository
    {
        SettingsModel Load();
        void Save(SettingsModel model);
    }
}
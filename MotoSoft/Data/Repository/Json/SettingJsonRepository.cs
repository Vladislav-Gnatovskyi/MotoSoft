using System;
using System.IO;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;

namespace MotoSoft.Data.Repository.Json
{
    public class SettingJsonRepository: ISettingsRepository
    {
        string settingsFileName = "settings.json";
        public SettingsModel Load()
        {
            if (File.Exists(settingsFileName))
            {
                string json = File.ReadAllText(settingsFileName);
                SettingsModel obj = JsonConvert.DeserializeObject<SettingsModel>(json);
                return obj;
            }
            return new SettingsModel();
        }

        public void Save(SettingsModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            File.WriteAllText(settingsFileName, json);
        }
    }
}

using System;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using System.Windows;

namespace MotoSoft.Models
{
    class SettingJsonRepository
    {
        public static SettingModel Load()
        {
            try
            {
                string json = File.ReadAllText("settings.json");
                SettingModel obj = JsonConvert.DeserializeObject<SettingModel>(json);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public static bool Save(SettingModel obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                File.WriteAllText("settings.json", json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

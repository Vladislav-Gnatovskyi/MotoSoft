using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository
{
    public class ActiveLotSheetJsonRepository:ISheetRepository<ActiveLotSheet>
    {
        private const string sheetFilename = "ActiveLotSheet.json";
        public IList<ActiveLotSheet> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<ActiveLotSheet> obj = JsonConvert.DeserializeObject<List<ActiveLotSheet>>(json);
                return obj;
            }
            return new List<ActiveLotSheet>();
        }

        public void Save(IList<ActiveLotSheet> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

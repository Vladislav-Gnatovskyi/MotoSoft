using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository
{
    public class SoldLotSheetRepository:ISheetRepository<SoldLotSheet>
    {
        private const string sheetFilename = "ActiveLotSheet.json";
        public IList<SoldLotSheet> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<SoldLotSheet> obj = JsonConvert.DeserializeObject<List<SoldLotSheet>>(json);
                return obj;
            }
            return new List<SoldLotSheet>();
        }

        public void Save(IList<SoldLotSheet> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

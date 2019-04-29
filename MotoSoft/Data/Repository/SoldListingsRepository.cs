using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository
{
    public class SoldListingsRepository:ISheetRepository<SoldListings>
    {
        private const string sheetFilename = "ActiveLotSheet.json";
        public IList<SoldListings> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<SoldListings> obj = JsonConvert.DeserializeObject<List<SoldListings>>(json);
                return obj;
            }
            return new List<SoldListings>();
        }

        public void Save(IList<SoldListings> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

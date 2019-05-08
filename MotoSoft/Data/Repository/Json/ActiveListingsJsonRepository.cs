using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository.Json
{
    public class ActiveListingsJsonRepository:ISheetRepository<ActiveListings>
    {
        private const string sheetFilename = "ActiveLotSheet.json";
        public IList<ActiveListings> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<ActiveListings> obj = JsonConvert.DeserializeObject<List<ActiveListings>>(json);
                return obj;
            }
            return new List<ActiveListings>();
        }

        public void Save(IList<ActiveListings> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

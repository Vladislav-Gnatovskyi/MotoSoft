using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

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

        public Task<IList<ActiveListings>> GetSheetAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IList<ActiveListings> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

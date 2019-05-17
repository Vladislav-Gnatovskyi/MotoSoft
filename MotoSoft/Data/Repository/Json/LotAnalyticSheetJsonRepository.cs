using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Data.Repository.Json
{
    public class LotAnalyticSheetJsonRepository : ISheetRepository<LotAnalyticSheet>
    {
        private const string sheetFilename = "LotAnalyticSheet.json";
        public IList<LotAnalyticSheet> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<LotAnalyticSheet> obj = JsonConvert.DeserializeObject<List<LotAnalyticSheet>>(json);
                return obj;
            }
            return new List<LotAnalyticSheet>();
        }

        public Task<IList<LotAnalyticSheet>> GetSheetAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IList<LotAnalyticSheet> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

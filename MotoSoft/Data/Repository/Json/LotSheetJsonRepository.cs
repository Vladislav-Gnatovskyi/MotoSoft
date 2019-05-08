using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Data.Repository.Json
{
    class LotSheetJsonRepository : ISheetRepository<LotSheet>
    {
        private const string sheetFilename = "LotSheet.json";
        public IList<LotSheet> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<LotSheet> obj = JsonConvert.DeserializeObject<List<LotSheet>>(json);
                return obj;
            }
            return new List<LotSheet>();
        }

        public void Save(IList<LotSheet> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

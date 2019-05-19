using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetJsonRepository : ISheetRepository<LotSheetsModel>
    {
        private const string sheetFilename = "LotSheet.json";
        public IList<LotSheetsModel> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<LotSheetsModel> obj = JsonConvert.DeserializeObject<List<LotSheetsModel>>(json);
                return obj;
            }
            return new List<LotSheetsModel>();
        }

        public Task<IList<LotSheetsModel>> GetSheetAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IList<LotSheetsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

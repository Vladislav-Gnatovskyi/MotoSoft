using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public async Task<IList<LotSheetsModel>> GetSheetAsync()
        {
            return await Task.Run(GetSheet);
        }

        public bool AddNewItem(LotSheetsModel item)
        {
            IList<LotSheetsModel> lotSheets = GetSheet();
            if (lotSheets.Where(x => x.Lot.Equals(item.Lot)).FirstOrDefault() != null) return false;
            lotSheets.Add(item);
            Save(lotSheets);
            return true;
        }

        public void Save(IList<LotSheetsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

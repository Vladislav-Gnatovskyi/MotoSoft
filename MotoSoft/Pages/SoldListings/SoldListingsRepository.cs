using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    public class SoldListingsRepository: ISheetRepository<SoldListingsModel>
    {
        private const string sheetFilename = "ActiveLotSheet.json";
        public IList<SoldListingsModel> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<SoldListingsModel> obj = JsonConvert.DeserializeObject<List<SoldListingsModel>>(json);
                return obj;
            }
            return new List<SoldListingsModel>();
        }

        public Task<IList<SoldListingsModel>> GetSheetAsync()
        {
            throw new System.NotImplementedException();
        }

        public void Save(IList<SoldListingsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

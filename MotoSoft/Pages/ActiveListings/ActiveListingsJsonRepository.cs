using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsJsonRepository: ISheetRepository<ActiveListingsModel>
    {
        private const string sheetFilename = "ActiveLotSheet.json";

        public event EventHandler DataChanged;

        public IList<ActiveListingsModel> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json = File.ReadAllText(sheetFilename);
                List<ActiveListingsModel> obj = JsonConvert.DeserializeObject<List<ActiveListingsModel>>(json);
                return obj;
            }
            return new List<ActiveListingsModel>();
        }

        public Task<IList<ActiveListingsModel>> GetSheetAsync()
        {
            return Task.Run(GetSheet);
        }
    }
}

using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Pages.ActiveListings
{
    public class ActiveListingsJsonRepository: ISheetRepository<ActiveListingsModel>
    {
        private const string sheetFilename = "ActiveLotSheet.json";

        public event EventHandler DataChanged;

        public bool AddNewItem(ActiveListingsModel item)
        {
            throw new NotImplementedException();
        }

        public bool EditItem(ActiveListingsModel NewItem, string OldItem)
        {
            throw new NotImplementedException();
        }

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

        public bool Remove(ActiveListingsModel item)
        {
            throw new NotImplementedException();
        }

        public void Save(IList<ActiveListingsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }

        public void Save(IList sheet)
        {
            throw new NotImplementedException();
        }
    }
}

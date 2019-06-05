using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MotoSoft.Pages.SoldListings
{
    public class SoldListingsJsonRepository: ISheetRepository<SoldListingsModel>
    {
        private const string sheetFilename = "SoldListing.json";

        public event EventHandler DataChanged;


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
            throw new NotImplementedException();
        }

        public void Save(IList sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

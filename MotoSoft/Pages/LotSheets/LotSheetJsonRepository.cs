using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSoft.Pages.LotSheets
{
    class LotSheetJsonRepository : ISheetRepository<LotSheetsModel>
    {
        private const string sheetFilename = "LotSheet.json";

        public event EventHandler DataChanged;

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
            if (item.Type == null || item.Make == null || item.Model == null || item.Notes == null || item.Cost.Equals(0) || item.Year.Equals(0)) return false;
            IList<LotSheetsModel> lotSheets = GetSheet();
            if (lotSheets.Where(x => x.Lot.Equals(item.Lot)).FirstOrDefault() != null) return false;
            SaveImages(ref item);
            lotSheets.Add(item);
            Save(lotSheets);
            DataChanged?.Invoke(this, EventArgs.Empty);
            return true;
        }

        public bool SaveImages(ref LotSheetsModel item)
        {
            if (!Directory.Exists(item.Lot.ToString()))
            {
                string Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MotoSoft/{item.Lot}/";
                Directory.CreateDirectory($"{Path}");
                File.Copy(item.Title, $"{Path}/Title.png");
                item.Title = $"{Path}/Title.png";
                File.Copy(item.Bos, $"{Path}/BillOfSale.png");
                item.Bos = $"{Path}/BillOfSale.png";
                return true;
            }
            return false;
        }

        public void Save(IList<LotSheetsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
        }
    }
}

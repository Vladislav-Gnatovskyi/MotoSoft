using MotoSoft.Frameworks.Pages;
using Newtonsoft.Json;
using System;
using System.Collections;
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
            Save(lotSheets.ToList());
            return true;
        }

        public bool EditItem(LotSheetsModel NewItem, string OldItemLot)
        {
            IList<LotSheetsModel> lotSheets = GetSheet();
            var OldItem = lotSheets.Where(x => x.Lot.ToString().Equals((OldItemLot))).FirstOrDefault();
            if (OldItem != null && (lotSheets.Where(item => item.Lot.Equals(NewItem.Lot)).FirstOrDefault() == null || NewItem.Lot.ToString().Equals(OldItemLot)))
            {
                lotSheets.Remove(OldItem);
                SaveImages(ref NewItem);
                Remove(OldItem);
                lotSheets.Add(NewItem);
                Save(lotSheets.ToList());
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Remove(LotSheetsModel item)
        {
            string Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MotoSoft/{item.Lot}";
            IList<LotSheetsModel> items = GetSheet();
            var itemRemove = items.Where(x => x.Lot.Equals(item.Lot)).FirstOrDefault();
            if (itemRemove != null)
            {
                if(Directory.Exists(Path)) Directory.Delete(Path,true);
                items.Remove(itemRemove);
                Save(items.ToList());
                return true;
            }
            return false;
        }

        public bool SaveImages(ref LotSheetsModel item)
        {
            if (!Directory.Exists(item.Lot.ToString()))
            {
                string Path = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MotoSoft/{item.Lot}/";
                Directory.CreateDirectory($"{Path}");
                if (File.Exists(item.Title) && item.Title != $"{Path}/Title.png")
                {
                    File.Copy(item.Title, $"{Path}/Title.png", true);
                    item.Title = $"{Path}/Title.png";
                }
                if (File.Exists(item.Bos) && item.Bos != $"{Path}/BillOfSale.png")
                {
                    File.Copy(item.Bos, $"{Path}/BillOfSale.png", true);
                    item.Bos = $"{Path}/BillOfSale.png";
                }
                return true;
            }
            return false;
        }

        public void Save(IList sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

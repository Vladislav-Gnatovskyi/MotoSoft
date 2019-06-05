using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Pages;
using MotoSoft.Pages.LotSheets.Vehicle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSoft.Pages.LotSheets
{
    public class LotSheetJsonRepository : ISheetRepository<LotSheetsModel>, ISheetUpdate<LotSheetsModel>
    {

        private string userFolder { get => $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MotoSoft/{ServiceProvider.Instance.SettingsRepository.Load()?.PayPal??"Default"}"; }
        private string sheetFilename { get => $"{userFolder}/LotSheet.json"; }

        public event EventHandler DataChanged;

        public bool AddItem(LotSheetsModel item)
        {
            if (item != null && item.Lot >= 10000 && !item.Type.Equals(ETypeVehicle.Nope) && item.Date != null)
            {
                IList<LotSheetsModel> sheets = GetSheet();
                if (sheets.Where(itemExist => itemExist.Equals(item) || itemExist.Lot.Equals(item.Lot)).FirstOrDefault() != null) return false;
                SaveImages(ref item);
                sheets.Add(item);                
                Save(sheets);
                return true;
            }
            return false;            
        }

        public bool EditItem(LotSheetsModel newItem, LotSheetsModel oldItem)
        {
            if (newItem != null && oldItem != null)
            {
                oldItem = Remove(oldItem, false);
                IList<LotSheetsModel> sheets = GetSheet();
                SaveImages(ref newItem);
                if (!oldItem.Lot.Equals(newItem.Lot))
                    RemoveImages(oldItem);
                sheets.Add(newItem);
                Save(sheets);
                return true;
            }
            return false;
        }

        public IList<LotSheetsModel> GetSheet()
        {
            if (File.Exists(sheetFilename))
            {
                string json;
                using (StreamReader reader = new StreamReader(sheetFilename))
                {
                    json = reader.ReadToEnd();
                }
                List<LotSheetsModel> obj = JsonConvert.DeserializeObject<List<LotSheetsModel>>(json);
                return obj;
            }
            return new List<LotSheetsModel>();
        }

        public async Task<IList<LotSheetsModel>> GetSheetAsync()
        {
            return await Task.Run(GetSheet);
        }

        public LotSheetsModel Remove(LotSheetsModel item, bool isDelete = true)
        {
            if(item != null)
            {
                IList<LotSheetsModel> sheets = GetSheet();
                LotSheetsModel itemRemoved = sheets.Where(itemExist => itemExist.Lot.Equals(item.Lot)).FirstOrDefault();
                if (itemRemoved != null)
                {
                    sheets.Remove(itemRemoved);
                    RemoveImages(itemRemoved, isDelete);
                    Save(sheets);
                    return itemRemoved;
                }
            }
            return null;
        }

        private bool RemoveImages(LotSheetsModel item, bool isDelete = true)
        {
            string folderPath = userFolder + "/" + item.Lot.ToString();
            string folderArchive = userFolder + "/Archive/" + item.Lot.ToString();
            if (Directory.Exists(folderPath))
            {
                if (isDelete)
                {
                    Directory.Delete(folderPath, true);
                }
                return true;
            }
            return false;
        }

        private bool SaveImages(ref LotSheetsModel item)
        {
            if (!Directory.Exists(item.Lot.ToString()))
            {
                string Path = GetPath(item);
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

        private string GetPath(LotSheetsModel item)
        {
            return $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}/MotoSoft/{ServiceProvider.Instance.EbayService.GetUser.Email}/{item.Lot}";
        }

        public void Save(IList<LotSheetsModel> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(sheetFilename, json);
            DataChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}

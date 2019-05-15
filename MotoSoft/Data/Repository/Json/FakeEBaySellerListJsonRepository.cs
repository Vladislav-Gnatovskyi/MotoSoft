using eBay.Service.Core.Soap;
using Newtonsoft.Json;
using System.IO;

namespace MotoSoft.Data.Repository.Json
{
    public class FakeEBaySellerListJsonRepository
    {
        string itemsFileName = "items.json";
        public ItemTypeCollection Load()
        {
            if (File.Exists(itemsFileName))
            {
                string json = File.ReadAllText(itemsFileName);
                ItemTypeCollection obj = JsonConvert.DeserializeObject<ItemTypeCollection>(json);
                return obj;
            }
            return new ItemTypeCollection { };
        }

        public void Save(ItemType[] model)
        {
            string json = JsonConvert.SerializeObject(model);
            File.WriteAllText(itemsFileName, json);
        }
    }
}

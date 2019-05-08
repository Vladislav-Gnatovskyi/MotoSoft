using eBay.Service.Core.Soap;
using Newtonsoft.Json;
using System.IO;

namespace MotoSoft.Data.Repository.Json
{
    public class FakeEBaySellerListJsonRepository
    {
        string itemsFileName = "items.json";
        public ItemType[] Load()
        {
            if (File.Exists(itemsFileName))
            {
                string json = File.ReadAllText(itemsFileName);
                ItemType[] obj = JsonConvert.DeserializeObject<ItemType[]>(json);
                return obj;
            }
            return new ItemType[] { };
        }

        public void Save(ItemType[] model)
        {
            string json = JsonConvert.SerializeObject(model);
            File.WriteAllText(itemsFileName, json);
        }
    }
}

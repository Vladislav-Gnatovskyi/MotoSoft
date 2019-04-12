using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace MotoSoft.Models
{
    class ProductsJsonRepository
    {
        public static List<Product> Load()
        {
            try
            {
                string json = File.ReadAllText("products.json");
                List<Product> obj = JsonConvert.DeserializeObject<List<Product>>(json);
                return obj;
            }
            catch
            {
                return null;
            }
        }

        public static bool Save(List<Product> obj)
        {
            try
            {
                string json = JsonConvert.SerializeObject(obj);
                File.WriteAllText("products.json", json);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Models
{
    class ProductsRepository
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

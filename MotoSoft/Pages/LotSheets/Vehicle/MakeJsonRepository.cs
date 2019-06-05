using MotoSoft.Pages.LotSheets.Vehicle.Interfaces;
using MotoSoft.Pages.LotSheets.Vehicle.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MotoSoft.Pages.LotSheets.Vehicle
{
    class MakeJsonRepository : IMakesRepository
    {
        public event EventHandler DataChanged;
        private const string _pathFile = "MakesRepository.json";

        public sbyte AddMake(Make item)
        {
            if (item == null) return 0;
            IList<Make> makes = GetMakes();
            if (makes.Where(makeExists => makeExists.Type.Equals(item.Type) && makeExists.Name.ToUpper().Equals(item.Name.ToUpper())).FirstOrDefault() == null)
            {
                makes.Add(item);
                Save(makes);
                return 1;
            }
            return -1;
        }

        public sbyte AddModel(Make make, Model model)
        {
            if (model == null || make == null) return 0;
            IList<Make> makes = GetMakes();
            Make itemMake = makes.Where(makeExists => makeExists.Name.ToUpper().Equals(make.Name.ToUpper()) && makeExists.Type.Equals(make.Type)).FirstOrDefault();
            if(itemMake != null)
            {
                if (itemMake.Add(model))
                {
                    makes.Remove(makes.Where(makeExists => makeExists.Name.ToUpper().Equals(make.Name.ToUpper()) && makeExists.Type.Equals(make.Type)).First());
                    makes.Add(itemMake);
                    Save(makes);
                    return 1;
                }
            }
            return -1;
        }

        public sbyte AddModel(Make make, string modelName)
        {
            if (modelName == "" || modelName == null || make == null) return 0;
            IList<Make> makes = GetMakes();
            Make itemMake = makes.Where(makeExists => makeExists.Name.ToUpper().Equals(make.Name.ToUpper()) && makeExists.Type.Equals(make.Type)).FirstOrDefault();
            if (itemMake != null)
            {
                if (itemMake.Add(modelName))
                {
                    makes.Remove(makes.Where(makeExists => makeExists.Name.ToUpper().Equals(make.Name.ToUpper()) && makeExists.Type.Equals(make.Type)).First());
                    makes.Add(itemMake);
                    Save(makes);
                    return 1;
                }
            }
            return -1;
        }


        public IList<Make> GetMakes()
        {
            if (File.Exists(_pathFile))
            {
                string json = File.ReadAllText(_pathFile);
                List<Make> obj = JsonConvert.DeserializeObject<List<Make>>(json);
                return obj;
            }
            return new List<Make>();
        }

        public async Task<IList<Make>> GetMakesAsync()
        {
            return await Task.Run(GetMakes);
        }

        public void Save(IList<Make> sheet)
        {
            string json = JsonConvert.SerializeObject(sheet);
            File.WriteAllText(_pathFile, json);
            DataChanged?.Invoke(this, EventArgs.Empty);
        }

        public IList<Model> GetModels(string name, ETypeVehicle type)
        {
            if(name != null || !type.Equals(ETypeVehicle.Nope))
            {
                Make make = GetMakes().Where(makeExists => makeExists.Name.Equals(name) && makeExists.Type.Equals(type)).FirstOrDefault();
                if(make != null)
                {
                    return make.Models.ToList();
                }
            }
            return new List<Model>();
        }
    }
}

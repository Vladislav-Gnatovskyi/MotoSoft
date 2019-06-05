using System.Collections.Generic;
using System.Linq;

namespace MotoSoft.Pages.LotSheets.Vehicle.Models
{
    public class Make
    {
        public Make(string name, ETypeVehicle type, List<Model> models = null)
        {
            Name = name;
            Type = type;
            Models = models ?? new List<Model>();
        }

        public ETypeVehicle Type { get; }
        public string Name { get; }

        public ICollection<Model> Models { get; }
        
        public int ModelsCount { get => Models.Count; }

        public bool Add(Model model)
        {
            if (Models.Where(modelExists => modelExists.Name.Equals(model.Name)).FirstOrDefault() == null)
            {
                Models.Add(model);
                return true;
            }
            return false;
        }

        public bool Add(string nameModel)
        {
            if (Models.Where(modelExists => modelExists.Name.Equals(nameModel)).FirstOrDefault() == null)
            {
                Models.Add(new Model(nameModel));
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}

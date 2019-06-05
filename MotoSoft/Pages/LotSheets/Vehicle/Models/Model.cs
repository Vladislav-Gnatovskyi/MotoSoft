namespace MotoSoft.Pages.LotSheets.Vehicle.Models
{
    public class Model
    {
        public string Name { get; set; }

        public Model() { }
        public Model(string name) { Name = name; }

        public override string ToString()
        {
            return Name;
        }
    }
}

using System.Windows.Input;

namespace MotoSoft.Frameworks.Components.Table
{
    public class ContextMenuField
    {
        public string Title { get; set; }
        public ICommand Action { get; set; }
    }
}

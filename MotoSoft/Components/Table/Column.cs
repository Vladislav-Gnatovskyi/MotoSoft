using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotoSoft.Components.Table
{
    public class Column
    {
        public string Title { get; set; }
        public string Field { get; set; }
        public int Width { get; set; }
        public int Hight { get; set; }
        public EColumnType Type { get; set; }
    }
}

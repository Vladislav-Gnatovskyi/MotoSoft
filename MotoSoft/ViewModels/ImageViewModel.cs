using MotoSoft.Assets.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MotoSoft.ViewModels
{
    public class ImageViewModel
    {
        public string DispayImagePath { get; set; }
        private Microsoft.Win32.OpenFileDialog dialog = new Microsoft.Win32.OpenFileDialog();

        public ICommand BFile_Click
        {
            get
            {
                return new RelayCommand(x => 
                {                 
                    Nullable<bool> result = dialog.ShowDialog();
                    if (result == true)
                    {
                        DispayImagePath = $@"{dialog.FileName}";
                    }
                });
            }
        }
    }
}

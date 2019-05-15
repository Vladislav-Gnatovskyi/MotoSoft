using Microsoft.Win32;
using MotoSoft.Assets.Command;
using System;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    public class ImageViewModel
    {
        public string DispayImagePath { get; set; }
        private readonly OpenFileDialog dialog = new OpenFileDialog();

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

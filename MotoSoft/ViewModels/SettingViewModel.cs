using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class SettingViewModel:ViewModelBase
    {
        public static SettingModel SettingModel { get; set; }

        public SettingViewModel()
        {
            SettingModel = new SettingModel();
            SettingModel = SettingRepository.Load();
        }

        #region OnClick

        public ICommand BSave_Click
        {
            get
            {
                return new RelayCommand(x => MessageBox.Show(SettingRepository.Save(SettingModel).ToString()));
            }
        }

        public ICommand BCancel_Click
        {
            get
            {
                return new RelayCommand(x => SettingModel = SettingRepository.Load());
            }
        }
        #endregion OnClick
    }
}

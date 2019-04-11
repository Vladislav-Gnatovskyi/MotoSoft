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
        public SettingModel SettingModel { get; set; }

        private static SettingViewModel _instance;
        public static SettingViewModel Instance => _instance ?? (_instance = new SettingViewModel());

        private SettingViewModel()
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

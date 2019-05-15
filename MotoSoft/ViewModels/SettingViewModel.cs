using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Data;
using MotoSoft.Data.eBay;
using MotoSoft.Data.Models;
using MotoSoft.Data.Repository.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;

namespace MotoSoft.ViewModels
{
    class SettingViewModel : ViewModelBase
    {
        private readonly ISettingsRepository settingsRepository;
        public SettingsModel SettingModel { get; set; }

        public SettingViewModel()
        {
            settingsRepository = ServiceProvider.Instance.SettingsRepository;
            SettingModel = settingsRepository.Load();
        }
        #region OnClick

        public ICommand BSingOut_Click
        {
            get
            {
                return new RelayCommand(x =>
                {
                    EBayAuthorize.SingOut();
                    Router.Instance.GoToAuthorize();
                });
            }
        }

        public ICommand BSave_Click
        {
            get
            {
                return new RelayCommand(x =>
                {
                    try
                    {
                        settingsRepository.Save(SettingModel);
                    }
                    catch(Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                });
            }
        }

        public ICommand BCancel_Click
        {
            get
            {
                return new RelayCommand(x => SettingModel = settingsRepository.Load());
            }
        }
        #endregion OnClick
    }
}

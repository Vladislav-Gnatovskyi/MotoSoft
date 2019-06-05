using DevExpress.Mvvm;
using MotoSoft.Frameworks;
using MotoSoft.Frameworks.Authorize;
using MotoSoft.Frameworks.Command;
using System;
using System.Windows;
using System.Windows.Input;

namespace MotoSoft.Pages.Settings
{
    class SettingViewModel : ViewModelBase
    {
        private readonly ISettingsRepository settingsRepository;
        public SettingsModel SettingModel { get; set; }

        public SettingViewModel()
        {
            settingsRepository = ServiceProvider.Instance.SettingsRepository;
            SettingModel = settingsRepository.Load();
            SettingModel.PayPal = ServiceProvider.Instance.EbayService.GetUser.Email;
            ServiceProvider.Instance.SettingsRepository.Save(SettingModel);
    }
        #region OnClick

        public ICommand BSingOut_Click
        {
            get
            {
                return new RelayCommand(x =>
                {
                    EBayAuthorize.Instance.SingOut();
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

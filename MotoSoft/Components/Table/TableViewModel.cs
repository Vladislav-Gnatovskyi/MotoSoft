using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.ViewModels;
using System.Windows.Input;

namespace MotoSoft.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        public IPageItem PageItemsContol { get; set; }
        public IDataSource Source { get; set; }

        #region Command
        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    PageItemsContol.NextPage();
                });
            }
        }
        public ICommand BackPage
        {
            get
            {
                return new RelayCommand(x =>
                {
                    PageItemsContol.BackPage();
                });
            }
        }

        public ICommand Refresh
        {
            get => new RelayCommand(x => { PageItemsContol = new PageItemsViewModel(Source); });
        }
        #endregion Command
    }
}

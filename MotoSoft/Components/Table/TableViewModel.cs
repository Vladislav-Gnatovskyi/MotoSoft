using DevExpress.Mvvm;
using MotoSoft.Assets.Command;
using MotoSoft.Data.DataSources;
using MotoSoft.ViewModels;
using System.Windows.Input;

namespace MotoSoft.Components.Table
{
    class TableViewModel:ViewModelBase
    {
        public IDataSource Source { get; set; }
        public IPageItem PageItemsContol { get; set; }
        
        public TableViewModel()
        {
            Source = new SoldListingsDataSource();
            PageItemsContol = new PageItemsViewModel(Source, 40);            
        }

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
        #endregion Command
    }
}

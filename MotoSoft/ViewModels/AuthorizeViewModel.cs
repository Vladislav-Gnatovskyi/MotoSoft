using DevExpress.Mvvm;
using MotoSoft.Data.eBay;

namespace MotoSoft.ViewModels
{
    class AuthorizeViewModel : ViewModelBase
    {
        private string _url;
        public string URL
        {
            get => _url;
            set
            {
                _url = value;
                var code = ebayAuthorize.GetAuthorizationCode(value);
                if(code != null)
                {
                    if (ebayAuthorize.GetToken(code) != null)
                    {
                        Router.Instance.GoToHome();
                    }
                }
            }
        }

        private EBayAuthorize ebayAuthorize;
        
        public AuthorizeViewModel()
        {
            ebayAuthorize = new EBayAuthorize();
            _url = ebayAuthorize.GetAuthorizeURL();
        }
    }
}

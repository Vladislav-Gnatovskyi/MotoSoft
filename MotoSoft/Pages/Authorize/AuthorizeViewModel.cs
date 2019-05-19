using DevExpress.Mvvm;
using MotoSoft.Frameworks.Authorize;

namespace MotoSoft.ViewModels
{
    class AuthorizeViewModel : ViewModelBase
    {
        public string URL => EBayAuthorize.Instance.AuthorizationUrl;
    }
}

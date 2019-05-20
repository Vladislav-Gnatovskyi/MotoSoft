using DevExpress.Mvvm;
using MotoSoft.Frameworks.Authorize;

namespace MotoSoft.ViewModels
{
    class AuthorizeViewModel : ViewModelBase
    {
        public string URL { get => EBayAuthorize.Instance.AuthorizationUrl; set => EBayAuthorize.Instance.AuthorizationUrl = value; }
    }
}

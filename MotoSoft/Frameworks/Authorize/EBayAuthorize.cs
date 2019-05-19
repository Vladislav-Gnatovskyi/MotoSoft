using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using MotoSoft.Pages.Settings;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace MotoSoft.Frameworks.Authorize
{
    public class EBayAuthorize
    {
        private static EBayAuthorize _instance;
        public static EBayAuthorize Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new EBayAuthorize();
                }
                return _instance; 
            }
        }
        public OAuthEnvironment Environment { get => OAuthEnvironment.SANDBOX; }

        private readonly string pathConfig = "ebay-config.yaml";
        private readonly string state = "State";
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly IList<string> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope",
        };
        private string _url;

        public ISettingsRepository SettingsRepository { get; }
        private string AccessToken { get; set; }

        public bool IsAuthorized
        {
            get
            {
                return AccessToken != null;
            }
        }

        private EBayAuthorize()
        {
            CredentialUtil.Load(pathConfig);
            SettingsRepository = ServiceProvider.Instance.SettingsRepository;
            AccessToken = ServiceProvider.Instance.CurrentContext.Settings.Token;
            // TODO: extend, need to check that token is still valid, made call for it to api and probably save timeout info
        }

        public string AuthorizationUrl
        {
            get
            {
                if (_url == null)
                {
                    _url = oAuth2Api.GenerateUserAuthorizationUrl(Environment, userScopes, state);
                }
                return _url;
            }
            set
            {
                _url = value;
                UpdateAccessToken();
            }
        }
        public void SingOut()
        {
            var setting = ServiceProvider.Instance.CurrentContext.Settings;
            AccessToken = null;
            setting.Token = null;
            SettingsRepository.Save(setting);
        }

        private void UpdateAccessToken()
        {
            var code = GetAuthorizationCode(AuthorizationUrl);
            if (code != null)
            {
                var response = oAuth2Api.ExchangeCodeForAccessToken(Environment, code);
                AccessToken = response.AccessToken.Token;
                var setting = ServiceProvider.Instance.CurrentContext.Settings;
                setting.Token = AccessToken;
                SettingsRepository.Save(setting);
            }
        }

        private string GetAuthorizationCode(string authorizationUrl)
        {
            if (authorizationUrl.Contains("code="))
            {
                int iqs = authorizationUrl.IndexOf('?');
                String querystring = (iqs < authorizationUrl.Length - 1) ? authorizationUrl.Substring(iqs + 1) : String.Empty;
                NameValueCollection queryParams = HttpUtility.ParseQueryString(querystring);
                String code = queryParams.Get("code");
                return code;
            }
            return null;
        }
    }
}

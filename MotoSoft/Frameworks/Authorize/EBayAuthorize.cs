using System;
using System.Web;
using System.Collections.Generic;
using System.Collections.Specialized;
using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using MotoSoft.Pages.Settings;

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
        public OAuthEnvironment Environment { get => OAuthEnvironment.PRODUCTION; }

        private readonly string pathConfig = "ebay-config.yaml";
        private readonly string state = "State";
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly IList<string> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope",
        };
        private string _url;

        public ISettingsRepository SettingsRepository { get; }
        private OAuthResponse Token { get; set; }

        public bool IsAuthorized
        {
            get
            {
                return  Token != null;
            }
        }

        private EBayAuthorize()
        {
            CredentialUtil.Load(pathConfig);
            SettingsRepository = ServiceProvider.Instance.SettingsRepository;
            Token = ServiceProvider.Instance.CurrentContext.Settings.Token;
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
                GenerateToken();
            }
        }
        public void SingOut()
        {
            var setting = ServiceProvider.Instance.CurrentContext.Settings;
            Token = null;
            setting.Token = null;
            SettingsRepository.Save(setting);
        }

        private void GenerateToken()
        {
            var code = GetAuthorizationCode(AuthorizationUrl);
            if (code != null)
            {
                var response = oAuth2Api.ExchangeCodeForAccessToken(Environment, code);
                Token = response;
                var setting = ServiceProvider.Instance.CurrentContext.Settings;
                setting.Token = Token;
                SettingsRepository.Save(setting);
            }
        }

        public bool GetAccesToken()
        {
            try
            { 
                Token = oAuth2Api.GetAccessToken(Environment, Token.RefreshToken.Token, userScopes);
                var setting = ServiceProvider.Instance.CurrentContext.Settings;
                setting.Token = Token;
                SettingsRepository.Save(setting);
                return true;
            }
            catch
            {
                var setting = ServiceProvider.Instance.CurrentContext.Settings;
                setting.Token = Token = null;
                SettingsRepository.Save(setting);
                return false;
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

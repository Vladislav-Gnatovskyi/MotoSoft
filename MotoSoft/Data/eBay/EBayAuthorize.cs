using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using MotoSoft.Data.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;

namespace MotoSoft.Data.eBay
{
    public class EBayAuthorize
    {
        #region PrivateProperty
        private string pathConfig { get => "ebay-config.yaml"; }
        private static string Token { get; set; }
        public static OAuthEnvironment Environment { get => OAuthEnvironment.SANDBOX; }
        private string state { get => "State"; }
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly IList<string> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope",
        };
        #endregion PrivateProperty

        #region PublicProperty
        public static EbayAuthorizeState IsAuthorize
        {
            get
            {
                return Token != null ? EbayAuthorizeState.Authorized : EbayAuthorizeState.NotAuthorized;
            }
        }
        #endregion PublicProperty

        public EBayAuthorize()
        {
            CredentialUtil.Load(pathConfig);
        }

        public string GetAuthorizeURL()
        {
            return oAuth2Api.GenerateUserAuthorizationUrl(Environment, userScopes, state); 
        }

        public string GetToken(string code)
        {          
            var reposn = oAuth2Api.ExchangeCodeForAccessToken(Environment, code);
            Token = reposn.AccessToken.Token;
            var setting = ServiceProvider.Instance.CurrentContext.Settings;
            setting.Token = Token;
            ServiceProvider.Instance.SettingsRepository.Save(setting);
            return Token;
        }

        public static void SingOut()
        {
            var setting = ServiceProvider.Instance.CurrentContext.Settings;
            setting.Token = Token = null;
            ServiceProvider.Instance.SettingsRepository.Save(setting);
        }
        public string GetAuthorizationCode(string authorizationUrl)
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

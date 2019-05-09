using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
using MotoSoft.Data.Enums;
using MotoSoft.Data.Repository.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using System.Web;

namespace MotoSoft.Data.eBay
{
    public class EBayAuthorize
    {
        #region PrivateProperty
        private string pathConfig { get => "ebay-config.yaml"; }
        private static string Token { get; set; }
        private OAuthEnvironment Environment { get => OAuthEnvironment.PRODUCTION; }
        private string state { get => "State"; }
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly IList<string> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope",
        };
        #endregion PrivateProperty

        #region PublicProperty
        public EbayAuthorizeState IsAuthorize
        {
            get
            {
                return Token != null ? EbayAuthorizeState.Authorized : EbayAuthorizeState.NotAuthorized;
            }
        }
        #endregion PublicProperty

        public EBayAuthorize()
        {
            Initial();
        }
        private void Initial()
        {
            if (IsAuthorize.Equals(EbayAuthorizeState.NotAuthorized) && ServiceProvider.Instance.CurrentContext.Settings.Token == null)
            {
                GetToken();
            }
        }

        public string GetToken()
        {
            CredentialUtil.Load(pathConfig);
            string authorizationUrl = oAuth2Api.GenerateUserAuthorizationUrl(Environment, userScopes, state);
            var reposn = oAuth2Api.ExchangeCodeForAccessToken(Environment, GetAuthorizationCode(authorizationUrl));
            Token = reposn.AccessToken.Token;
            var settingModel = ServiceProvider.Instance.CurrentContext.Settings;
            settingModel.Token = Token;
            new SettingJsonRepository().Save(settingModel);
            return Token;
        }

        private string GetAuthorizationCode(string authorizationUrl)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(service);
            string successUrl = null;
            driver.Navigate().GoToUrl(authorizationUrl);
            IWebElement userId = driver.FindElement(By.Id("userid"));
            IWebElement password = driver.FindElement(By.Id("pass"));
            IWebElement submit = driver.FindElement(By.Id("sgnBt"));
            //userId.SendKeys("gnatovskyi@gmail.com");
            //password.SendKeys("");
            //submit.Click();
            //Wait for success page
            //Thread.Sleep(30000);
            do
            {               
                    successUrl = driver.Url;
            }
            while (!successUrl.Contains("code="));
            //Handle consent
            if (successUrl.Contains("/consents"))
            {
                IWebElement consent = driver.FindElement(By.Id("submit"));
                consent.Click();
                Thread.Sleep(2000);
                successUrl = driver.Url;
            }
            int iqs = successUrl.IndexOf('?');
            String querystring = (iqs < successUrl.Length - 1) ? successUrl.Substring(iqs + 1) : String.Empty;
            NameValueCollection queryParams = HttpUtility.ParseQueryString(querystring);
            String code = queryParams.Get("code");
            driver.Quit();
            return code;
        }
    }
}

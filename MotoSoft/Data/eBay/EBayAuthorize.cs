using eBay.ApiClient.Auth.OAuth2;
using eBay.ApiClient.Auth.OAuth2.Model;
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
        private string pathConfig { get => "ebay-config.yaml"; }
        public static bool IsAuthorize {
            get
            {
                return Token != null ? true : false;
            }
        }
        public string Code { get; private set; }
        public static string Token { get; private set; }
        private string state { get => "State"; }

        private OAuth2Api oAuth2Api = new OAuth2Api();

        private readonly IList<string> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope",
        };

        public EBayAuthorize()
        {
            CredentialUtil.Load(pathConfig);
            string authorizationUrl = oAuth2Api.GenerateUserAuthorizationUrl(OAuthEnvironment.PRODUCTION, userScopes, state);
            Code = GetAuthorizationCode(authorizationUrl);
            var reposn = oAuth2Api.ExchangeCodeForAccessToken(OAuthEnvironment.PRODUCTION, Code);
            Token = reposn.AccessToken.Token;
        }

        private String GetAuthorizationCode(String authorizationUrl)
        {
            ChromeDriverService service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;
            IWebDriver driver = new ChromeDriver(service);
            string successUrl = null;
            //Submit login form
            driver.Navigate().GoToUrl(authorizationUrl);
            //IWebElement userId = driver.FindElement(By.Id("userid"));
            //IWebElement password = driver.FindElement(By.Id("pass"));
            //IWebElement submit = driver.FindElement(By.Id("sgnBt"));
            //userId.SendKeys(userCredential.UserName);
            //password.SendKeys(userCredential.Pwd);
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

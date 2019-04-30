using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eBay.ApiClient.Auth.OAuth2.Model;
using eBay.ApiClient.Auth.OAuth2;
using MotoSoft.Data.Enums;
using System.Windows;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.Threading;
using OpenQA.Selenium;
using System.Web;
using System.Collections.Specialized;
using MotoSoft.Data.Models;

namespace MotoSoft.Data
{
    class EbayApiService
    {
        private string pathConfig { get => "ebay-config.yaml"; }
        private string state { get => "State"; }
        private OAuth2Api oAuth2Api = new OAuth2Api();
        private readonly IList<String> scopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope/buy.marketing",
                "https://api.ebay.com/oauth/api_scope"
        };
        private readonly IList<String> userScopes = new List<String>()
        {
                "https://api.ebay.com/oauth/api_scope/commerce.catalog.readonly",
                "https://api.ebay.com/oauth/api_scope/buy.shopping.cart"
        };

        public EbayApiService()
        {            
            CredentialUtil.Load(pathConfig);
            string authorizationUrl = oAuth2Api.GenerateUserAuthorizationUrl(OAuthEnvironment.PRODUCTION, userScopes, state);
            MessageBox.Show(GetAuthorizationCode(authorizationUrl, new UserCredential { UserName = "gnatovskyi@gmail.com", Pwd = "********" }));
        }

        private String GetAuthorizationCode(String authorizationUrl, UserCredential userCredential)
        {

            IWebDriver driver = new ChromeDriver("./");

            //Submit login form
            driver.Navigate().GoToUrl(authorizationUrl);
            IWebElement userId = driver.FindElement(By.Id("userid"));
            IWebElement password = driver.FindElement(By.Id("pass"));
            IWebElement submit = driver.FindElement(By.Id("sgnBt"));
            userId.SendKeys(userCredential.UserName);
            password.SendKeys(userCredential.Pwd);
            submit.Click();

            //Wait for success page
            Thread.Sleep(2000);

            String successUrl = driver.Url;

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
            // Parse the query string variables into a NameValueCollection.
            NameValueCollection queryParams = HttpUtility.ParseQueryString(querystring);
            String code = queryParams.Get("code");
            driver.Quit();

            return code;

        }


    }
}

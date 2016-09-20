using ISAA.Rules.StockAutomation;
using ISAA.Rules.StockAutomation.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Suppliers.Ali.Automation.Common
{
    internal static class ShopCart
    {
        public static CookieContainer MakeNewCookieContainerRequest()
        {
            var cookieContainer = new CookieContainer();

            var requestGet = (HttpWebRequest)HttpWebRequest.Create("http://www.Ali.com.br/");

            requestGet.Method = "GET";
            requestGet.CookieContainer = cookieContainer;

            var getResponse = requestGet.GetResponse();

            getResponse.Close();

            return cookieContainer;
        }

        public static void MakeAddShopCartRequest(Ali_Product product, CookieContainer cookieContainer)
        {
            var data = new
            {
                ProdutoCodigo = product.ReferenceID,
                Results = product.Ali_ProductSku
                    .Select(item => string.Format("{0}|{1}|{2}", item.FeatureCode, item.PartNumber, 100))
                    .ToArray(),
                VitrineCodigo = 0
            };

            var jsonText = JsonConvert.SerializeObject(data);
            var requestPost = (HttpWebRequest)HttpWebRequest.Create("http://www.Ali.com.br/ajaxpro/IKCLojaMaster.detalhes,Ali.ashx");

            requestPost.Headers.Add("X-AjaxPro-Method", "AdicionarItensTabela");

            var bytes = Encoding.UTF8.GetBytes(jsonText);

            requestPost.Timeout = 60000; 
            requestPost.Accept = "*/*";
            requestPost.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";
            requestPost.ContentType = "text/plain; charset=utf-8";
            requestPost.Referer = "http://www.Ali.com.br/";
            requestPost.Method = "post";
            requestPost.ContentLength = bytes.Length;
            requestPost.CookieContainer = cookieContainer;

            var requestStream = requestPost.GetRequestStream();

            requestStream.Write(bytes, 0, bytes.Length);

            requestPost.GetResponse().Close();
        }

        public static void MakeLoadShopCartRequest(CookieContainer container)
        {
            var requestGet = (HttpWebRequest)HttpWebRequest.Create("http://www.Ali.com.br/basket/index.aspx");

            requestGet.Timeout = 5000;
            requestGet.Accept = "*/*";
            requestGet.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";
            requestGet.Method = "get";
            requestGet.CookieContainer = container;

            var response = requestGet.GetResponse();

            response.Close();
        }

        public static ProductStock[] MakeGetShopCartRequest(CookieContainer cookieContainer)
        {
            var requestPost = (HttpWebRequest)HttpWebRequest.Create("http://www.Ali.com.br/basket/index.aspx/LoadSummaryBasket");

            requestPost.Timeout = 60000;
            requestPost.UserAgent = "Mozilla/5.0 (Windows NT 6.3; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/47.0.2526.106 Safari/537.36";
            requestPost.Accept = "*/*";
            requestPost.Referer = "http://www.Ali.com.br";
            requestPost.Method = "POST";
            requestPost.ContentType = "application/json; charset=utf-8";
            requestPost.ContentLength = 0;
            requestPost.CookieContainer = cookieContainer;

            using (var postResponse = requestPost.GetResponse())
            using (var postResponseStream = postResponse.GetResponseStream())
            using (var postResponseStreamReader = new StreamReader(postResponseStream))
            {
                var responseText = postResponseStreamReader.ReadToEnd();
                var jToken = JsonConvert.DeserializeObject(responseText) as JToken;

                if (jToken["d"].ToObject<Object>() == null)
                {
                    return new ProductStock[0];
                }

                return jToken["d"]["Items"].ToObject<ProductStock[]>();
            }
        }

        public static CookieContainer GetCookieContainer(long productReferenceID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var rules = RulesCreator.NewRules<StockAutomationRules>(db);
                var shopCart = rules.GetLastShopCart(productReferenceID);

                if (shopCart == null)
                {
                    return CreateShopCart(productReferenceID);
                }

                var cookieContainer = new CookieContainer();
                var cookieShopCart = new Cookie("CestaCliente", shopCart.ShopCartID, "/", ".Ali.com.br");

                cookieContainer.Add(cookieShopCart);

                return cookieContainer;
            }
        }

        public static CookieContainer CreateShopCart(long productReferenceID)
        {
            var cookieContainer = MakeNewCookieContainerRequest();
            var cookies = cookieContainer.GetCookies(new Uri("http://Ali.com.br"));
            var shopCartCookie = cookies["CestaCliente"];

            using (var db = AliShopDbEntities.New())
            {
                var rules = RulesCreator.NewRules<StockAutomationRules>(db);

                rules.CreateShopCart(productReferenceID, shopCartCookie.Value);
            }

            return cookieContainer;
        }

        public static void SetUpdateShopCart(long productReferenceID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var rules = RulesCreator.NewRules<StockAutomationRules>(db);
                var shopCart = rules.GetLastShopCart(productReferenceID);

                shopCart.LastUpdate = DateTime.UtcNow;

                db.SaveChanges();
            }
        }

        public static long GetLastProductProcessID()
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules.GetProcessSuccessOrderByDesc("UpdateAllProduct");
            }
        }

        public static long[] GetAllProductIDs(long productProcessID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules
                    .GetProductByProcessID(productProcessID)
                    .Select(i => i.Ali_ProductID)
                    .ToArray();
            }
        }

        public static Ali_Product[] GetAllProduct(long productProcessID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules
                    .GetProductByProcessID(productProcessID, "Ali_ProductSku")
                    .ToArray();
            }
        }

        public static Ali_Product GetProductByID(long productID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules.GetProductByID(productID, "Ali_ProductSku").SingleOrDefault();
            }
        }

        public static long CreateProcessID(string type, bool keepAlive)
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules.CreateProcess(type, keepAlive);
            }
        }

        public static Ali_Process UpdateProcessByID(long processID)
        {
            using (var db = AliShopDbEntities.New())
            {
                var productRules = RulesCreator.NewRules<StockAutomationRules>(db);

                return productRules.UpdateProcessByID(processID);
            }
        }
    }
}

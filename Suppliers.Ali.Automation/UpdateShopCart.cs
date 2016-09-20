using ISAA.Suppliers.Ali.Automation.Common;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ISAA.Suppliers.Ali.Automation
{
    internal static class UpdateShopCart
    {
        public static void Run(long? productProcessID, bool alwaysUpdate, int? maxDegreeOfParallelism)
        {
            var shopCartProcessID = ShopCart.CreateProcessID("UpdateShopCart", false);

            if (productProcessID == null)
            {
                productProcessID = ShopCart.GetLastProductProcessID();
            }

            var allProductIDs = ShopCart.GetAllProductIDs(productProcessID.Value);

            var items = allProductIDs.Select(i => new Item
            {
                AlwaysUpdate = alwaysUpdate,
                ProductID = i
            }).ToArray();

            var partitioner = Partitioner.Create(items, true);
            var parallelOptions = new ParallelOptions();

            parallelOptions.MaxDegreeOfParallelism = maxDegreeOfParallelism ?? AppSettings.UpdateShopCartMaxDegreeOfParallelism ?? -1;

            Parallel.ForEach(partitioner, parallelOptions, AddShopCart);

            ShopCart.UpdateProcessByID(shopCartProcessID);
        }

        private static void AddShopCart(Item item)
        {
            var product = ShopCart.GetProductByID(item.ProductID);

            Program.PrintStatus(product, "BeforeRun", product.Url);

            var cookieContainer = ShopCart.GetCookieContainer(product.ReferenceID);

            Program.Try(product.ReferenceID.ToString(), product.Url, 3, delegate ()
            {
                var inShopCart = ShopCart.MakeGetShopCartRequest(cookieContainer);
                var allStock = inShopCart
                   .Where(stock => stock != null)
                   .Select(stock => new
                   {
                       ProductStock = stock,
                       Keys = stock.MessageItem.Substring(0, stock.MessageItem.IndexOf('(')).Split('/')
                   });

                var needUpdate = product.Ali_ProductSku.Any(sku =>
                {
                    var color = "COR:" + Regex.Replace(sku.Color, "[^a-z0-9]*", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    var size = "TAMANHO:" + Regex.Replace(sku.Size, "[^-a-z0-9]*", "", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    var stockKey = allStock.Where(stock => stock.Keys.Contains(color) && stock.Keys.Contains(size));

                    return !stockKey.Any();
                });

                if (needUpdate || item.AlwaysUpdate)
                {
                    ShopCart.MakeAddShopCartRequest(product, cookieContainer);

                    Program.PrintStatus(product, "RunComplete", product.Url, ConsoleColor.Green);
                }
                else
                {
                    Program.PrintStatus(product, "Needless", product.Url, ConsoleColor.Blue);
                }
            });

            ShopCart.SetUpdateShopCart(product.ReferenceID);
        }

        public class Item
        {
            public bool AlwaysUpdate { get; set; }

            public long ProductID { get; set; }
        }
    }
}

using ISAA.Helper.ConsoleHelper;
using ISAA.Helper.PhantomJS;
using ISAA.Suppliers.Ali.Automation.Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;

namespace ISAA.Suppliers.Ali.Automation
{
    public class Program
    {
        public static CultureInfo CulturePtBr = CultureInfo.GetCultureInfo("pt-br");

        public static void PhantomConfig()
        {
            PhantomControl.CONFIG_LOAD_IMAGES = false;
            PhantomControl.CONFIG_PROXY = new[] { "true", "0" }.Contains(ConfigurationManager.AppSettings["ProxyCredential:UseProxy"].ToLower());
            PhantomControl.CONFIG_PROXY_ADDRESS = ConfigurationManager.AppSettings["ProxyCredential:Address"];
            PhantomControl.CONFIG_PROXY_PASSWORD = ConfigurationManager.AppSettings["ProxyCredential:Password"];
            PhantomControl.CONFIG_PROXY_USERNAME = ConfigurationManager.AppSettings["ProxyCredential:UserName"];
        }

        public static void Main(string[] args)
        {
            Argument.SetArgument(args);

            PhantomConfig();

            var suppressHeader = Argument.GetArgumentBool("-SuppressHeader");

            if (!suppressHeader)
            {
                Print.PrintDescription(Assembly.GetExecutingAssembly());
            }

            if (Argument.HasArgument("-H"))
            {
                PrintHelper();

                return;
            }

            if (Run(suppressHeader))
            {
                return;
            }

            Print.SetOutToConsole();

            PrintHelper();
        }

        public static bool Run(bool suppressHeader)
        {
            ChangeOutputType();

            if (!suppressHeader)
            {
                Print.PrintText("AliGetProduct", "");

                Console.WriteLine();
            }

            var productId = Argument.GetArgumentLong("-ProductId", true);
            var storeId = Argument.GetArgumentInt("-StoreId", true);

            var model = new Models.GetProductModel
            {
                ProductId = productId.Value,
                RefName = productId.Value.ToString(),
                Url = AppSettings.AliExpressProductDetailUrl
                  .Replace("{store_id}", storeId.Value.ToString())
                  .Replace("{product_id}", productId.Value.ToString())
            };

            GetProductDetails(model);

            return true;
        }

        public static ProductDetailModel GetProductDetails(GetProductModel item)
        {
            var job = new Job(item.Url, JobConfiguration.AliExpressProductScript);

            Print.PrintStatus(item.RefName, "BeforeRun", item.Url);

            Program.Try(item.RefName, item.Url, 3, () => job.Run());

            var productDetail = default(ProductDetailModel);

            if (job.ReturnedJSON != null)
            {
                productDetail = JsonConvert.DeserializeObject<ProductDetailModel>(job.ReturnedJSON);

                Print.PrintStatus(item.RefName, "RunComplete", item.Url, ConsoleColor.Green);
                Print.PrintStatus(item.RefName, "JsonResult", item.Url + Environment.NewLine + JsonConvert.SerializeObject(productDetail), ConsoleColor.Green);
            }
            else
            {
                Print.PrintStatus(item.RefName, "Error", item.Url + Environment.NewLine + job.ReturnedValue, ConsoleColor.Red);
            }

            return productDetail;
        }

        public static void PrintHelper()
        {
            Console.WriteLine();

            Print.PrintText("Help", "");

            Console.WriteLine();

            Print.PrintText("-OutputType", "Output Type, default is Console [ Enum {{ Console | TextFile }} ] [ OPTIONAL ].");
            Print.PrintText("-SuppressHeader", "Suppress header, assembly information [ BOOL ] [ OPTIONAL ].");
            Print.PrintText("-H", "For help, with -MethodName for help for method [ BOOL ] [ OPTIONAL ].");
        }

        public static void ChangeOutputType()
        {
            if (Argument.HasArgument("-OutputType"))
            {
                var outputType = (OutputType)Enum.Parse(typeof(OutputType), Argument.GetArgumentString("-OutputType"));

                if (outputType == OutputType.TextFile)
                {
                    var outputFileName = Print.NewOutputFileName();

                    Print.PrintText("OutputType", "Change to TextFile: {0}", outputFileName.Substring(outputFileName.IndexOf("./")));

                    Print.SetOutToTextFile(outputFileName);
                }
            }
        }

        public static bool Try(string refID, string text, int? maxAttempts, bool supressOutpuError, Action action)
        {
            var attemps = 0;

            do
            {
                attemps++;

                try
                {
                    action();

                    return true;
                }
                catch (Exception e)
                {
                    if (!supressOutpuError)
                    {
                        Print.PrintText(
                            ConsoleColor.Red,
                            DateTime.UtcNow.ToString(),
                            "{0} RefId {1} {2}",
                            "Error".PadRight(15, ' '),
                            refID.PadRight(8, ' '),
                            string.Format("{0}{1}Attemps: {2}{3}{4}",
                                text,
                                Environment.NewLine,
                                attemps,
                                Environment.NewLine,
                                e.ToString()));
                    }
                }
            }
            while (maxAttempts == null || attemps < maxAttempts);

            return false;
        }

        public static bool Try(string refID, string text, Action action)
        {
            return Try(refID, text, 3, false, action);
        }

        public static bool Try(string refID, string text, bool supressOutpuError, Action action)
        {
            return Try(refID, text, 3, supressOutpuError, action);
        }

        public static bool Try(string refID, string text, int? maxAttempts, Action action)
        {
            return Try(refID, text, maxAttempts, false, action);
        }

        public static string ToTitle(string text)
        {
            if (text == null)
            {
                return null;
            }

            var items = new[]
            {
                "\r\n",
                "\n",
            };

            foreach (var c in items)
            {
                text = text.Replace(c, " ");
            }

            return CulturePtBr.TextInfo.ToTitleCase(text.ToLower()).Trim().Replace("  ", " ");
        }
    }
}

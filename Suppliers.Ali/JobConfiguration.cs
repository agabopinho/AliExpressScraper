using ISAA.Helper.PhantomJS;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Suppliers.Ali
{
    public static class JobConfiguration
    {
        private static string aliExpressProductScript = BaseDirectories.GetJsScriptDirectory() + "AliExpress.Product.js";

        public static string AliExpressProductScript
        {
            get
            {
                return aliExpressProductScript;
            }

            set
            {
                aliExpressProductScript = value;
            }
        }

        public static string GetNewProcessDirectory()
        {
            var newName = DateTime.Now.ToString("s").Replace("-", "").Replace(":", "");
            var dirName = BaseDirectories.GetDirectory(string.Format("./PROCESS/{0}/", newName));

            Directory.CreateDirectory(dirName);

            return dirName;
        }
    }
}

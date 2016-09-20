using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AliScrapperConsole
{
    public class BaseDirectories
    {
        public static string CurrentDir()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }

        public static string GetJsScriptDirectory()
        {
            return CurrentDir() + "./JS_SCRIPT/";
        }

        public static string GetDirectory(string name)
        {
            return CurrentDir() + name;
        }
    }
}

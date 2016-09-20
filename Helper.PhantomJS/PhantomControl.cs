using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Helper.PhantomJS
{
    public class PhantomControl : NReco.PhantomJS.PhantomJS, IDisposable
    {
        public static bool CONFIG_PROXY = false;
        public static string CONFIG_PROXY_USERNAME = null;
        public static string CONFIG_PROXY_PASSWORD = null;
        public static string CONFIG_PROXY_ADDRESS = null;
        public static bool CONFIG_LOAD_IMAGES = true;

        private bool disposed = false;

        public PhantomControl()
        {
            if (CONFIG_PROXY)
            {
                SetProxyAddress(CONFIG_PROXY_ADDRESS);
                SetProxyAuth(CONFIG_PROXY_USERNAME, CONFIG_PROXY_PASSWORD);
            }

            if (!CONFIG_LOAD_IMAGES)
            {
                SetLoadImages(false);
            }
        }

        /// <summary>
        /// Execute javascript code from specified file with input/output interaction
        /// </summary>
        /// <param name="jsFile">URL or local path to javascript file to execute</param>
        /// <param name="jsArgs">arguments for javascript code (optional; can be null)</param>
        /// <param name="inputStream">input stream for stdin data (can be null)</param>
        /// <returns>Return output stream for stdout data</returns>
        public virtual Stream Run(string jsFile, string[] jsArgs, Stream inputStream)
        {
            var outputStream = new MemoryStream();

            Run(jsFile, jsArgs, inputStream, outputStream);

            outputStream.Position = 0;

            return outputStream;
        }

        protected virtual void ReadyCustomArgs()
        {
            if (CustomArgs == null)
            {
                CustomArgs = "";
            }

            if (CustomArgs != "" && !CustomArgs.EndsWith(" "))
            {
                CustomArgs = CustomArgs + " ";
            }
        }

        public virtual void SetLoadImages(bool value)
        {
            AddConfig("load-images", value.ToString().ToLower());
        }

        public virtual void SetProxyAddress(string address)
        {
            AddConfig("proxy", address);
        }

        public virtual void SetProxyAuth(string userName, string password)
        {
            AddConfig("proxy-auth", string.Format("{0}:{1}", userName, password));
        }

        public virtual void AddConfig(string name, string value)
        {
            ReadyCustomArgs();

            if (!name.StartsWith("--"))
            {
                name = "--" + name;
            }

            CustomArgs += string.Format("{0}={1}", name, value);
        }

        protected void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {    
                }

                Abort();

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        ~PhantomControl()
        {
            Dispose(false);
        }
    }
}

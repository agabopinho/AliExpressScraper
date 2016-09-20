using ISAA.Helper.PhantomJS;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ISAA.Suppliers.Ali
{
    public class Job
    {
        static CultureInfo CultureEnUs = CultureInfo.GetCultureInfo("en-us");

        private StateType readyState;

        public Job(string navigateUrl, string jsFile)
        {
            NavigateUrl = navigateUrl;
            JsFile = jsFile;
        }

        public string NavigateUrl { get; set; }

        public string JsFile { get; set; }

        public StateType ReadyState
        {
            get
            {
                return readyState;
            }
            protected set
            {
                readyState = value;

                if (StateChanged != null)
                {
                    StateChanged(this, new JobEventArgs(this));
                }
            }
        }

        public string ReturnedValue { get; private set; }

        public string ReturnedJSON
        {
            get
            {
                if (ReturnedValue != null)
                {
                    var key = "JSON_RESULT";
                    var lines = ReturnedValue.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
                    var jsonLine = lines.LastOrDefault(item => item.StartsWith(key));

                    if (jsonLine != null)
                    {
                        return jsonLine.Substring(key.Length).Trim();
                    }
                }

                return null;
            }
        }

        public event EventHandler<JobEventArgs> StateChanged;

        public void Run()
        {
            using (var phantomJS = new PhantomControl())
            {
                ReadyState = StateType.BeforeRun;

                var outputStream = phantomJS.Run(JsFile, new[] { NavigateUrl }, null);

                using (outputStream)
                using (var reader = new StreamReader(outputStream, Encoding.UTF8))
                {
                    ReturnedValue = reader.ReadToEnd();
                }

                ReadyState = StateType.RunComplete;
            }
        }

        public void TestReturnedJsonValue()
        {
            if (ReturnedJSON != null)
            {
                JsonConvert.DeserializeObject(ReturnedJSON);
            }
        }

        public enum StateType
        {
            BeforeRun,
            RunComplete,
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Helper.ConsoleHelper
{
    public static class Argument
    {
        public static string[] Arguments { get; set; }

        public static string GetArgumentString(string name, bool required = false)
        {
            var value = Arguments.FirstOrDefault(item =>
                item.Trim().ToLowerInvariant().StartsWith(name.ToLowerInvariant() + "="));

            if (value == null)
            {
                if (required)
                {
                    throw new ArgumentNullException(name);
                }

                return null;
            }

            return value.Substring(name.Length + 1).Trim();
        }

        public static bool GetArgumentBool(string name, bool required = false)
        {
            var value = Argument.GetArgumentString(name, required);

            if (value == null)
            {
                return false;
            }

            value = value.ToLowerInvariant();

            if (!new[] { "true", "false" }.Contains(value))
            {
                throw new ArgumentOutOfRangeException(name);
            }

            return value == "true";
        }

        public static long? GetArgumentLong(string name, bool required = false)
        {
            var value = Argument.GetArgumentString(name, required);

            if (value == null)
            {
                return null;
            }

            return long.Parse(value);
        }

        public static int? GetArgumentInt(string name, bool required = false)
        {
            var value = Argument.GetArgumentString(name, required);

            if (value == null)
            {
                return null;
            }

            return int.Parse(value);
        }

        public static bool HasArgument(string name)
        {
            return Arguments.Any(item =>
                item.Trim().ToLowerInvariant() == name.ToLowerInvariant() ||
                item.Trim().ToLowerInvariant().StartsWith(name.ToLowerInvariant() + "="));
        }

        public static void SetArgument(string[] args)
        {
#if DEBUG
            if (args == null || args.Length == 0)
            {
                var argumentList = new List<string>();

                Console.Write("Arguments required: ");

                var value = Console.ReadLine();

                args = value.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            }
#endif

            Argument.Arguments = args;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ISAA.Helper.ConsoleHelper
{
    public class Print
    {
        static Print()
        {
            CurrentOutputType = OutputType.Console;
            InitialOut = Console.Out;
        }

        public static OutputType CurrentOutputType { get; private set; }

        public static string CurrentOutputFile { get; private set; }

        public static TextWriter InitialOut { get; private set; }

        public static void SetOutToConsole()
        {
            CurrentOutputType = OutputType.Console;
            CurrentOutputFile = null;
            Console.SetOut(InitialOut);
        }

        public static void SetOutToTextFile(string outputFileName)
        {
            var textWriter = File.CreateText(outputFileName);

            textWriter.AutoFlush = true;

            CurrentOutputType = OutputType.TextFile;
            CurrentOutputFile = outputFileName;
            Console.SetOut(textWriter);
        }

        public static string NewOutputFileName()
        {
            var fileName = string.Format("./CONSOLE-OUTPUT/{0}-{1}.txt", DateTime.UtcNow.ToString("yyyyMMddTHHmmss"), Guid.NewGuid());
            var fullName = Dir.CurrentDir() + fileName;
            var consoleOuputDirName = Path.GetDirectoryName(fullName);

            if (!Directory.Exists(consoleOuputDirName))
            {
                Directory.CreateDirectory(consoleOuputDirName);
            }

            return fullName;
        }

        public static void PrintText(ConsoleColor color, string name, string value, params object[] args)
        {
            var separator = " ";

            for (var i = 0; i < 25 - name.Length; i++)
            {
                separator += " ";
            }

            Console.ForegroundColor = color;

            Console.WriteLine(string.Format(" {0}{1}{2}", name, separator, value), args);

            Console.ResetColor();
        }

        public static void PrintText(string name, string value, params object[] args)
        {
            PrintText(ConsoleColor.Gray, name, value, args);
        }

        public static void PrintStatus(string refID, string name, string value, ConsoleColor color = ConsoleColor.Gray)
        {
            Print.PrintText(color, DateTime.UtcNow.ToString(), "{0} RefId {1} {2}", (name ?? "").PadRight(25, ' '), (refID ?? "").ToString().PadRight(8, ' '), value);
        }

        public static void PrintDescription(Assembly assembly)
        {
            Console.WriteLine();

            PrintText("Assembly", "");

            Console.WriteLine();

            PrintText(" Title", assembly.GetCustomAttribute<AssemblyTitleAttribute>().Title);
            PrintText(" Company", assembly.GetCustomAttribute<AssemblyCompanyAttribute>().Company);
            PrintText(" Copyright", assembly.GetCustomAttribute<AssemblyCopyrightAttribute>().Copyright);
            PrintText(" Trademark", assembly.GetCustomAttribute<AssemblyTrademarkAttribute>().Trademark);
            PrintText(" Description", assembly.GetCustomAttribute<AssemblyDescriptionAttribute>().Description);
            PrintText(" Version", assembly.GetName().Version.ToString());

            Console.WriteLine();
        }
    }
}

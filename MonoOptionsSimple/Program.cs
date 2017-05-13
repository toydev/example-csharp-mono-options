using System;
using System.Collections.Generic;
using System.Reflection;

using Mono.Options;

namespace MonoOptionsSimple
{
    class Program
    {
        static void Main(string[] args)
        {
            string value = "";
            bool option = false;
            bool help = false;

            OptionSet options = new OptionSet()
            {
                { "v|value=", "Example to receive a value.", v => value = v },
                { "o|option", "Example to receive a option.", v => option = v != null },
                { "h|help", "Show help and exit.", v => help = v != null },
            };

            List<string> extra;
            try
            {
                extra = options.Parse(args);
                if (help)
                {
                    Usage(options);
                    return;
                }

                Console.WriteLine("value ={0}", value);
                Console.WriteLine("option={0}", option);
                Console.WriteLine("extra ={0}", string.Join(",", extra));
            }
            catch (OptionException e)
            {
                Console.Write("{0}: ", Assembly.GetExecutingAssembly().FullName);
                Console.WriteLine(e.Message);
                Console.WriteLine("Try `{0} --help' for more information.", Assembly.GetExecutingAssembly().FullName);
                return;
            }
        }

        static void Usage(OptionSet options)
        {
            Console.WriteLine("Usage: {0} [OPTIONS]+", Assembly.GetExecutingAssembly().FullName);
            Console.WriteLine("Application Description Here.");
            Console.WriteLine();

            Console.WriteLine("Options:");
            options.WriteOptionDescriptions(Console.Out);
        }
    }
}

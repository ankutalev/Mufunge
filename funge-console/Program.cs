using System;
using System.Collections.Generic;
using System.Linq;
using funge_98.Languages;
using Befunge93 = funge_98.Languages.Befunge93;

namespace funge_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var helpOptions = new[]
            {
                "-h",
                "--h",
                "--help",
                "-help"
            };
            if (args.Length == 0 || helpOptions.Any(args.Contains))
            {
                DisplayHelp();
                return;
            }
            var onlyStandardExtensions = args.All(ho => ho != "--ignore-ext");
            var kunteynir = new Container.Container(new List<string>{"funge-98"});

            var initDict = new Dictionary<string, Func<FungeFamilyLanguage>>
            {
                {"--befunge93", kunteynir.Resolve<Befunge93> },
                {"--funge98", kunteynir.Resolve<Befunge98> },
            };
            
            foreach (var s in args)
            {
                if (initDict.TryGetValue(s, out var lang))
                {
                    var l =  lang();
                    RunFungeProgram(l,args,onlyStandardExtensions);
                }
            }
            
            RunFungeProgram(kunteynir.Resolve<Befunge98>(), args, onlyStandardExtensions);
        }

        private static void RunFungeProgram(FungeFamilyLanguage cp, string[] args, bool onlyStandardExts)
        {
            var result = cp.RunProgram(args, onlyStandardExts);
            if (result != null)
            {
                Console.WriteLine($"Error : {result}");
            }

            Environment.Exit(cp.ExitCode);
        }

        private static void DisplayHelp()
        {
            Console.WriteLine("Mufunge CLI - tools for running & debugging funge code");
            Console.WriteLine("Usage: mufunge program_file [opt1] [opt2] ... ");
            Console.WriteLine("Available options:");
            Console.WriteLine("-h,--h, -help, --help - display help");
            Console.WriteLine("--ignore-ext - forces Mufunge to execute funge code from file with any extension (by default standard only extension allowed");
            Console.WriteLine("--unefunge, --befunge93, --funge98, --trefunge - runs code in chosen standard (--funge98 default)");
            Console.WriteLine("--debug - run debugger");
        }
    }
}
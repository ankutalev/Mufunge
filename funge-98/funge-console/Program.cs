using System.Collections.Generic;
using funge_98.FactoriesStuff;
using funge_98.Languages;
using funge_98.Parsers;

namespace funge_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kunteynir = new Container.Container(new List<string>{"funge-98"});
            var cp =  kunteynir.Resolve<CommandProducer>();
            var language = new Befunge_93(cp, new Befunge93FileParser(args[0],true)); 
            language.RunProgram();
        }
    }
}
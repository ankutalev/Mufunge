using System.Collections.Generic;
using funge_98.FactoriesStuff;
using funge_98.Languages;

namespace funge_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kunteynir = new Container.Container(new List<string>{"funge-98"});
            var language =  kunteynir.Resolve<Befunge_93>();
            language.RunProgram();
        }
    }
}
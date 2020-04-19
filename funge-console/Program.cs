using System;
using System.Collections.Generic;
using funge_98.Languages;

namespace funge_console
{
    class Program
    {
        static void Main(string[] args)
        {
            var kunteynir = new Container.Container(new List<string>{"funge-98"});
            var cp =  kunteynir.Resolve<Befunge98>();
            var result = cp.RunProgram(args[0],true);
            if (result != null)
            {
                Console.Write(c);
            }
            Console.WriteLine(i.ToString().ToCharArray().ToString());
        }
    }
}
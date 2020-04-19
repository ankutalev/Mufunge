using System;
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
            int i = 0x452e472e;
            Console.WriteLine(i);
            foreach (var c in i.ToString().ToCharArray())
            {
                Console.Write(c);
            }
            Console.WriteLine(i.ToString().ToCharArray().ToString());
        }
    }
}
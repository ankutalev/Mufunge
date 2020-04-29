using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attributes;
using funge_98.Exceptions;

namespace funge_98.Parsers
{
    [ContainerElement]
    public class Befunge93FileParser : ISourceCodeParser
    {

        public IEnumerable<string> GetSourceCode(string filename, bool onlyStandardExtension)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            
            if (onlyStandardExtension)
            {
                if (!filename.EndsWith(".bf"))
                    throw new IncorrectExtensionException("Befunge-93 source code file must have .bf extension.");
                return File.ReadLines(filename);
            }
            
            return File.ReadLines(filename).Select(s=>s.Substring(0,80)).Take(25);
        }
    }
}
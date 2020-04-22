using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attributes;
using funge_98.Exceptions;

namespace funge_98.Parsers
{
    [ContainerElement]
    public class Befunge98FileParser : ISourceCodeParser
    {

        public IEnumerable<string> GetSourceCode(string filename, bool onlyStandardExtension)
        {
            if (!File.Exists(filename))
            {
                throw new FileNotFoundException();
            }
            if (onlyStandardExtension && !filename.EndsWith(".b98"))
            {
                throw new IncorrectExtensionException("Befunge-98 source code file must have .bf extension.");
            }

            foreach (var line in File.ReadLines(filename))
            {
                yield return new string(line.Where(x=> x!='\f').ToArray());
            }

            File.ReadLines(filename);
        }
    }
}
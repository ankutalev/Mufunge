using System.Collections.Generic;
using System.IO;
using Attributes;
using funge_98.Exceptions;

namespace funge_98.Parsers
{
    [Unefunge,ContainerElement]
    public class UnefungeFileParser : ISourceCodeParser
    {
        public IEnumerable<string> GetSourceCode(string filename, bool onlyStandardExtension)
        {
            if (onlyStandardExtension)
            {
                if (!filename.EndsWith(".bf"))
                    throw  new IncorrectExtensionException("Unefunge files must ends on .bf. I guess...");
            }
            return File.ReadLines(filename);
        }
    }
}
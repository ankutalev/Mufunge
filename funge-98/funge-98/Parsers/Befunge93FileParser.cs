using System.Collections.Generic;
using System.IO;
using System.Linq;
using funge_98.Exceptions;
using funge_98.ExecutionContexts;

namespace funge_98.Parsers
{
    public class Befunge93FileParser : ISourceCodeParser
    {
        private readonly string _filename;
        private readonly bool _onlyStandardExtension;

        public Befunge93FileParser(string filename, bool onlyStandardExtension)
        {
            _filename = filename;
            _onlyStandardExtension = onlyStandardExtension;
        }

        

        public IEnumerable<string> GetSourceCode()
        {
            if (!_filename.EndsWith(".bf"))
            {
                throw new IncorrectExtensionException("Befunge-93 source code file must have .bf extension.");
            }

            return File.ReadLines(_filename);
        }
    }
}
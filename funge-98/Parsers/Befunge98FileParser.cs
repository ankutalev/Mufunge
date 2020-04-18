using System.Collections.Generic;
using System.IO;
using funge_98.Exceptions;

namespace funge_98.Parsers
{
    public class Befunge98FileParser : ISourceCodeParser
    {
        private readonly string _filename;
        private readonly bool _onlyStandardExtension;

        public Befunge98FileParser(string filename, bool onlyStandardExtension)
        {
            _filename = filename;
            _onlyStandardExtension = onlyStandardExtension;
        }

        

        public IEnumerable<string> GetSourceCode()
        {
            if (!File.Exists(_filename))
            {
                throw new FileNotFoundException();
            }
            if (_onlyStandardExtension && !_filename.EndsWith(".b98"))
            {
                throw new IncorrectExtensionException("Befunge-98 source code file must have .bf extension.");
            }

            return File.ReadLines(_filename);
        }
    }
}
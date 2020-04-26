using System.Collections.Generic;

namespace funge_98.Parsers
{
    public interface ISourceCodeParser
    {
        IEnumerable<string> GetSourceCode(string filename, bool onlyStandardExtension);
    }
}
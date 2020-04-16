using System.Collections.Generic;
using funge_98.ExecutionContexts;

namespace funge_98.Parsers
{
    public interface ISourceCodeParser
    {
        IEnumerable<string> GetSourceCode();
    }
}
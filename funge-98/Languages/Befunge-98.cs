using System.Collections.Generic;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.FingerPrints;
using funge_98.Parsers;

namespace funge_98.Languages
{
    public class Befunge_98 : FungeFamilyLanguage
    {
        public Befunge_98(CommandProducer commandProducer,ISourceCodeParser parser, List<IFingerPrint> fps) : base(new Befunge98Context(parser,fps), commandProducer)
        {
        }
    }
}
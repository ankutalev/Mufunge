using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;
using funge_98.Parsers;

namespace funge_98.Languages
{
    public class Befunge_93 : FungeFamilyLanguage
    {
        public Befunge_93(CommandProducer commandProducer, ISourceCodeParser parser) : base(new Befunge93Context(parser), commandProducer)
        {
        }
    }
}
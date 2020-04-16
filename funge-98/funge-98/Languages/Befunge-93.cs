using Attributes;
using funge_98.ExecutionContexts;
using funge_98.FactoriesStuff;

namespace funge_98.Languages
{
    [ContainerElement]
    public class Befunge_93 : FungeFamilyLanguage
    {
        public Befunge_93(CommandProducer commandProducer) : base(new Befunge93Context(), commandProducer)
        {
        }
    }
}
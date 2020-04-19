using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class SplitCommand : ICommand
    {
        public char Name { get; } = 't';

        public string RealExecute(FungeContext fungeContext)
        {
            //todo
            return null;
        }
    }
}
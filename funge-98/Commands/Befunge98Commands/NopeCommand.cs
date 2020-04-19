using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class NopeCommand : ICommand
    {
        public char Name { get; } = 'z';

        public string RealExecute(FungeContext fungeContext)
        {
            return null;
        }
    }
}
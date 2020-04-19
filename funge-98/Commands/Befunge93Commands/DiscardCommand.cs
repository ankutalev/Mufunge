using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]
    public class DiscardCommand : ICommand
    {
        public char Name { get; } = '$';

        public string RealExecute(FungeContext fungeContext)
        {
            fungeContext.GetTopStackTopValues(1);
            return null;
        }
    }
}
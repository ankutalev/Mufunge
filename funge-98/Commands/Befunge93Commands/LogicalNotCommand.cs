using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]
    public class LogicalNotCommand : ICommand
    {
        public char Name { get; } = '!';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            fungeContext.PushToTopStack(values[0] == 0 ? 1 : 0);
            return null;
        }
    }
}
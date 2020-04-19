using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, Unefunge]
    public class GreaterThanCommand : ICommand
    {
        public char Name { get; } = '`';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(2);
            fungeContext.PushToTopStack(values[1] > values[0] ? 1 : 0);
            return null;
        }
    }
}
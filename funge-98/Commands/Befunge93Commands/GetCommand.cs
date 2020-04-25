using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, Unefunge]
    public class GetCommand : ICommand
    {
        public char Name { get; } = 'g';

        public string RealExecute(FungeContext fungeContext)
        {
            var coords = fungeContext.GetTopStackTopValues(fungeContext.Dimension);
            var value = fungeContext.GetCellValue(new DeltaVector(coords.Reverse().ToArray()) +
                                                  fungeContext.CurrentThread.StorageOffset);
            fungeContext.PushToTopStack(value);
            return null;
        }
    }
}
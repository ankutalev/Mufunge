using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, Unefunge]
    public class PutCommand : ICommand
    {
        public char Name { get; } = 'p';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(fungeContext.Dimension + 1);
            var targetCell = new DeltaVector(values.Reverse().Skip(1).ToArray()) +
                             fungeContext.CurrentThread.StorageOffset;
            fungeContext.ModifyCell(targetCell, values.Last());
            return null;
        }
    }
}
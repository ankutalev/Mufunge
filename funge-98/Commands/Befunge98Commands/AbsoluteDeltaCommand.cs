using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]
    public class AbsoluteDeltaCommand : ICommand
    {
        public char Name { get; } = 'x';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(fungeContext.Dimension);
            fungeContext.CurrentThreadDeltaVector = new DeltaVector(values.Reverse().ToArray());
            return null;
        }
    }
}
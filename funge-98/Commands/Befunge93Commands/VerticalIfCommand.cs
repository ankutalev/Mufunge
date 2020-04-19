using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [Befunge93]
    [ContainerElement]
    public class VerticalIfCommand : ICommand
    {
        public char Name { get; } = '|';

        public string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.CurrentThread.DeltaVector = value == 0 ? new DeltaVector(0, 1, 0) : new DeltaVector(0, -1, 0);
            return null;
        }
    }
}
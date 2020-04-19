using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]

    public class HorizontalIfCommand : ICommand
    {
        public char Name { get; } = '_';

        public string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.CurrentThread.DeltaVector = value == 0 ? new DeltaVector(1, 0, 0) : new DeltaVector(-1, 0, 0); 
            return null;
        }
    }
}
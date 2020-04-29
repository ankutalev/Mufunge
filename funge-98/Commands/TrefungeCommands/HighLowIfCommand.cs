using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.TrefungeCommands
{
    [ContainerElement,Trefunge]
    public class HighLowIfCommand : ICommand
    {
        public char Name { get; } = 'm';
        public string RealExecute(FungeContext fungeContext)
        {
            var b = fungeContext.GetTopStackTopValues(1)[0];
            var dv = b > 0 ? new DeltaVector(0,0,-1) : new DeltaVector(0, 0, 1);
            fungeContext.CurrentThreadDeltaVector = dv;
            return null;
        }
    }
}
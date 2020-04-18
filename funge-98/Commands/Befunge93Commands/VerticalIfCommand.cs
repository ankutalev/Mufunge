using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class VerticalIfCommand : Command
    {
        public override char Name { get; } = '|';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.CurrentThread.DeltaVector = value == 0 ? new DeltaVector(0,1,0) : new DeltaVector(0,-1,0);
            return null;
        }
    }
}
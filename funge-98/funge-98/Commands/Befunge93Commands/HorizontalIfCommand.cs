using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class HorizontalIfCommand : Command
    {
        public override char Name { get; } = '_';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.SetDeltaVector(value == 0 ? Direction.EAST : Direction.WEST);
            return null;
        }
    }
}
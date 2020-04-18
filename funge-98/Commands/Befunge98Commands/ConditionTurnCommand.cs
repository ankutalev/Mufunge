using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class ConditionTurnCommand : Command
    {
        public override char Name { get; } = 'w';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(2);
            if (values[0] == values[1])
                return null;
            
            var currentDelta = fungeContext.CurrentDirectionVector;
            fungeContext.CurrentDirectionVector = currentDelta.Rotate(values[1] > values[0] ? Direction.EAST : Direction.WEST);
            return null;
        }
    }
}
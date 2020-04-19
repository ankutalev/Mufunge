using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class ConditionTurnCommand : ICommand
    {
        public char Name { get; } = 'w';

        public string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(2);
            if (values[0] == values[1])
                return null;

            var currentDelta = fungeContext.CurrentThreadDeltaVector;
            fungeContext.CurrentThreadDeltaVector =
                currentDelta.Rotate(values[1] > values[0] ? Direction.East : Direction.West);
            return null;
        }
    }
}
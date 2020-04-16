using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class VerticalIfCommand : Command
    {
        public VerticalIfCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.SetDeltaVector(value == 0 ? Direction.SOUTH : Direction.NORTH);
            return null;
        }
    }
}
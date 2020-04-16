using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class GreaterThanCommand : Command
    {
        public GreaterThanCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetStackTopValues(2);
            fungeContext.PushToStack(values[1] > values[0] ? 1 : 0);
            return null;
        }
    }
}
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class SwapCommand : Command
    {
        public SwapCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetStackTopValues(2);
            fungeContext.PushToStack(values[0]);
            fungeContext.PushToStack(values[1]);
            return null;
        }
    }
}
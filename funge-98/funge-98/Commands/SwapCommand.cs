using funge_98.ExecutionContexts;

namespace funge_98.Commands
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
            if (fungeContext.GetStackTopValues(2, out var values))
            {
                return "Stack empty!";
            }
            fungeContext.PushToStack(values[0]);
            fungeContext.PushToStack(values[1]);
            return null;
        }
    }
}
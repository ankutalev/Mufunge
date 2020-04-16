using funge_98.ExecutionContexts;

namespace funge_98.Commands
{
    public class DuplicateCommand : Command
    {
        public DuplicateCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            if (fungeContext.GetStackTopValues(1, out var values))
            {
                return "Stack empty!";
            }
            fungeContext.PushToStack(values[0]);
            fungeContext.PushToStack(values[0]);
            return null;
        }
    }
}
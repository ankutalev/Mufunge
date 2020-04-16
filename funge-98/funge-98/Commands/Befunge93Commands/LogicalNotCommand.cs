using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class LogicalNotCommand : Command
    {
        public LogicalNotCommand(char name)
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
            fungeContext.PushToStack(values[0] == 0 ? 1 : 0 );
            return null;
        }
    }
}
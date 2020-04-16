using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class DiscardCommand : Command
    {
        public DiscardCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.GetStackTopValues(1);
            return null;
        }
    }
}
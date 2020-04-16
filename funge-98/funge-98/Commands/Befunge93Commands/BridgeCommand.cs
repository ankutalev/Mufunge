using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class BridgeCommand : Command
    {
        public BridgeCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.Trampoline();
            return null;
        }
    }
}
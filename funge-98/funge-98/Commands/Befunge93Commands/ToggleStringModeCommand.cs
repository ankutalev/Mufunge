using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class ToggleStringModeCommand : Command
    {
        public ToggleStringModeCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.ToggleStringMode();
            return null;
        }
    }
}
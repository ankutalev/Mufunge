using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class SpaceCommand : Command
    {
        public SpaceCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.ProcessSpace();
            return null;
        }
    }
}
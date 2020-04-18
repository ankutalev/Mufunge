using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class NopeCommand : Command
    {
        public override char Name { get; } = 'z';
        protected override string RealExecute(FungeContext fungeContext)
        {
            return null;
        }
    }
}
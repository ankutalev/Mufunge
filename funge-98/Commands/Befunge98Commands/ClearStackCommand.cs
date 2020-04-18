using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class ClearStackCommand : Command
    {
        public override char Name { get; } = 'n';
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.ClearTopStack();
            return null;
        }
    }
}
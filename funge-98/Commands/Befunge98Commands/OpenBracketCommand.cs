using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class OpenBracketCommand : Command
    {
        public override char Name { get; } = '(';
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();

            return null;
        }
    }
}
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class DiscardCommand : Command
    {
        public override char Name { get; } = '$';

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.GetTopStackTopValues(1);
            return null;
        }
    }
}
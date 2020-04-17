using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class DuplicateCommand : Command
    {
        public override char Name { get; } = ':';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            fungeContext.PushToTopStack(values[0]);
            fungeContext.PushToTopStack(values[0]);
            return null;
        }
    }
}
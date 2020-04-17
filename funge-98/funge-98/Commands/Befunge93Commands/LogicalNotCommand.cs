using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class LogicalNotCommand : Command
    {
        public override char Name { get; } = '!';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(1);
            fungeContext.PushToTopStack(values[0] == 0 ? 1 : 0);
            return null;
        }
    }
}
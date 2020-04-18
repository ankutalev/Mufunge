using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class GetCommand : Command
    {
        public override char Name { get; } = 'g';

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StorageGet();
            return null;
        }
    }
}
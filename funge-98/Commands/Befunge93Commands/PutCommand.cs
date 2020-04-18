using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PutCommand : Command
    {
        public override char Name { get; } = 'p';

        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StoragePut();
            return null;
        }
    }
}
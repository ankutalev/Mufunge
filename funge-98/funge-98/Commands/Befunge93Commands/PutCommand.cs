using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PutCommand : Command
    {
        public PutCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.StoragePut();
            return null;
        }
    }
}
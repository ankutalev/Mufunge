using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class InputFileCommand : Command
    {
        public override char Name { get; } = 'i';
        protected override string RealExecute(FungeContext fungeContext)
        {
            return null;
            // throw new System.NotImplementedException();
        }
    }
}
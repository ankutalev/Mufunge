using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PushHexNumberCommand : Command
    {
        public PushHexNumberCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToTopStack(int.Parse(Name.ToString(), System.Globalization.NumberStyles.HexNumber));
            return null;
        }
    }
}
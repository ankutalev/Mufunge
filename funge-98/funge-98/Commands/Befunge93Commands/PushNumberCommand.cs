using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PushNumberCommand : Command
    {
        public PushNumberCommand(char name)
        {
            Name = name;
        }

        public override char Name { get; }
        protected override string RealExecute(FungeContext fungeContext)
        {
            fungeContext.PushToStack(int.Parse(Name.ToString(), System.Globalization.NumberStyles.HexNumber));
            return null;
        }
    }
}
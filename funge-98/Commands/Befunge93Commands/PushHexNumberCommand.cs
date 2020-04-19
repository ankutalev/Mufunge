using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    [ContainerElement, UnefungeCommand]

    public class PushHexNumberCommand : ICommand
    {
        public PushHexNumberCommand(char name)
        {
            Name = name;
        }

        public char Name { get; }

        public string RealExecute(FungeContext fungeContext)
        {
            //todo wtf
            try
            {
                fungeContext.PushToTopStack(int.Parse(Name.ToString(), System.Globalization.NumberStyles.HexNumber));
            }
            catch
            {
                fungeContext.PushToTopStack(Name);
            }

            return null;
        }
    }
}
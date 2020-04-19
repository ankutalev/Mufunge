using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]

    public class InputFileCommand : ICommand
    {
        public char Name { get; } = 'i';

        public string RealExecute(FungeContext fungeContext)
        {
            //todo
            return null;
            // throw new System.NotImplementedException();
        }
    }
}
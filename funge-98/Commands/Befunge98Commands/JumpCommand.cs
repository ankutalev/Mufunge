using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]

    public class JumpCommand : ICommand
    {
        public char Name { get; } = ';';

        public bool CanTick => false;

        public string RealExecute(FungeContext fungeContext)
        {
            do
            {
                fungeContext.MoveCurrentThread();
            } while (fungeContext.GetCellValue(fungeContext.CurrentThread.CurrentPosition) != Name);

            return null;
        }
    }
}
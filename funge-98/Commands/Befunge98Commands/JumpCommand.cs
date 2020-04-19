using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98Command]

    public class JumpCommand : ICommand
    {
        public char Name { get; } = ';';

        public bool CanTick => false;

        public string RealExecute(FungeContext fungeContext)
        {
            do
            {
                fungeContext.MoveOnce();
            } while (fungeContext.GetCellValue(fungeContext.CurrentThread.CurrentPosition) != Name);

            return null;
        }
    }
}
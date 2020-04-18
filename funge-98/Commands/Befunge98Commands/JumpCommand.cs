using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class JumpCommand : Command
    {
        public override char Name { get; } = ';';

        public override bool CanTick => false;

        protected override string RealExecute(FungeContext fungeContext)
        {
            do
            {
                fungeContext.MoveOnce();
            } while (fungeContext.GetCellValue(fungeContext.CurrentThread.CurrentPosition) != Name);

            fungeContext.MoveOnce();
            return null;
        }
    }
}
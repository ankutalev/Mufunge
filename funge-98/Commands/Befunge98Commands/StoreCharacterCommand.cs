using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class StoreCharacterCommand : Command
    {
        public override char Name { get; } = 's';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var value = fungeContext.GetTopStackTopValues(1)[0];
            fungeContext.StoragePut(fungeContext.CurrentThread.CurrentPosition + fungeContext.CurrentThreadDeltaVector,value);
            fungeContext.MoveOnce();
            return null;
        }
    }
}
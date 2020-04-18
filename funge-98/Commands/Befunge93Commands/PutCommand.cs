using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge93Commands
{
    public class PutCommand : Command
    {
        public override char Name { get; } = 'p';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(fungeContext.Dimension + 1);
            var targetCell = new DeltaVector(values.Reverse().Skip(1).ToArray()) + fungeContext.CurrentThread.StorageOffset;
            fungeContext.StoragePut(targetCell,values.Last());
            return null;
        }
    }
}
using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class AbsoluteDeltaCommand : Command
    {
        public override char Name { get; } = 'x';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var values = fungeContext.GetTopStackTopValues(fungeContext.Dimension);
            fungeContext.CurrentDirectionVector = new DeltaVector(values.Reverse().ToArray());
            return null;
        }
    }
}
using System;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class JumpForward : Command
    {
        public override char Name { get; } = 'j';
        protected override string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            var delta = n < 0 ? fungeContext.CurrentThreadDeltaVector.Reflect() : fungeContext.CurrentThreadDeltaVector;
            for (int i = 0; i < Math.Abs(n); i++)
            {
                fungeContext.CurrentThread.CurrentPosition += delta;
            }

            return null;
        }
    }
}
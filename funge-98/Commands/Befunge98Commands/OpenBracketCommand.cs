using System.Collections.Generic;
using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    public class OpenBracketCommand : Command
    {
        private readonly List<FingerPrintCommand> _fpc;

        public OpenBracketCommand( List<FingerPrintCommand> fpc)
        {
            _fpc = fpc;
        }
        public override char Name { get; } = '(';

        protected override string RealExecute(FungeContext fungeContext)
        {
            var n = fungeContext.GetTopStackTopValues(1)[0];
            if (n < 0)
            {
                return "UB in \"(\" : top stack value negative";
            }

            var values = fungeContext.GetTopStackTopValues(n).Reverse().ToArray();

            var accum = values.Aggregate(0, (current, value) => current * 256 + value);

            var fps = fungeContext.SupportedFingerPrints;
            var fp = fps.Find(f => f.FingerPrintHash == accum);
            if (fp == null)
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            foreach (var (key,f) in fp.KeyBinding)
            {
                _fpc.Find(c=>c.Name ==key)?.ApplyAlias(f);
            }

            return null;
        }
    }
}
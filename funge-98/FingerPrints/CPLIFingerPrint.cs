using System;
using System.Collections.Generic;
using funge_98.ExecutionContexts;

namespace funge_98.FingerPrints
{
    public class CpliFingerPrint : FingerPrint
    {
        public override string Name => "CPLI";

        public override Dictionary<char, Func<FungeContext, string>> KeyBinding
        {
            get
            {
                var d = new Dictionary<char, Func<FungeContext, string>>
                {
                    ['A'] = AFunc
                };
                return d;
            }
        }

        private static string AFunc(FungeContext context)
        {
            var complexes = context.GetTopStackTopValues(4);
            context.PushToTopStack(complexes[0] + complexes[2]);
            context.PushToTopStack(complexes[1] + complexes[3]);
            return null;
        }
    }
}
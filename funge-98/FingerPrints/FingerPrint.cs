using System;
using System.Collections.Generic;
using System.Linq;
using funge_98.ExecutionContexts;

namespace funge_98.FingerPrints
{
    public abstract class FingerPrint
    {
        public abstract string Name { get; }

        int FingerPrintHash => Name.Aggregate(0, (current, c) => current * 256 + c);
        public abstract Dictionary<char, Func<FungeContext, string>> KeyBinding { get; }
    }
}
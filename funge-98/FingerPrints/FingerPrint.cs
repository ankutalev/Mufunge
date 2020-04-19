using System;
using System.Collections.Generic;
using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.FingerPrints
{
    [ContainerElement]
    public abstract class FingerPrint
    {
        public abstract string Name { get; }
        public bool Enabled { get; set; }

        public int FingerPrintHash => Name.Aggregate(0, (current, c) => current * 256 + c);
        public abstract Dictionary<char, Func<FungeContext, string>> KeyBinding { get; }
    }
}
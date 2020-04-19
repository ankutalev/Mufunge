using System;
using System.Collections.Generic;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.FingerPrints
{
    [ContainerElement]
    public class NULLFingerPrint : FingerPrint
    {
        public override string Name { get; } = "NULL";

        public override Dictionary<char, Func<FungeContext, string>> KeyBinding
        {

            get
            {
                var d = new Dictionary<char, Func<FungeContext, string>>();
                for (var i = 'A'; i <= 'Z'; i++)
                {
                    d.Add(i, context => null);
                }
                return d;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.FingerPrints
{
    [ContainerElement]
    public class NULLFingerPrint : IFingerPrint
    {
        public  string Name { get; } = "NULL";

        public Dictionary<char, Func<FungeContext, string>> KeyBinding
        {

            get
            {
                var d = new Dictionary<char, Func<FungeContext, string>>();
                for (var i = 'A'; i <= 'Z'; i++)
                {
                    d.Add(i, context =>
                    {
                        context.CurrentThreadDeltaVector = context.CurrentThreadDeltaVector.Reflect();
                        return null;
                    });
                }
                return d;
            }
        }
    }
}
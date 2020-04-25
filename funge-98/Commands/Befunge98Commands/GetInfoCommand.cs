using System;
using System.IO;
using System.Linq;
using Attributes;
using funge_98.Enums;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class GetInfoCommand : ICommand
    {
        public char Name { get; } = 'y';

        public string RealExecute(FungeContext fungeContext)
        {
            //todo
            var value = fungeContext.GetTopStackTopValues(1)[0];
            var values = Enumerable.Repeat(GetFlagsInfo(fungeContext.Settings), 1)
                .Append(sizeof(int))
                .Append(FungeContext.HandPrint.Aggregate(0, (cur, c) => cur * 5 + c))
                .Append(FungeContext.NumericVersion)
                .Append(1) //use system();
                .Append(Path.DirectorySeparatorChar)
                .Append(fungeContext.Dimension)
                .Append(fungeContext.CurrentThread.Id)
                .Append(0) //teamId not supported
                .Concat(fungeContext.CurrentThread.CurrentPosition.Coords(fungeContext.Dimension).Reverse())
                .Concat(fungeContext.CurrentThreadDeltaVector.Coords(fungeContext.Dimension).Reverse())
                .Concat(fungeContext.CurrentThread.StorageOffset.Coords(fungeContext.Dimension).Reverse())
                .Concat(fungeContext.GetLeastPoint().Coords(fungeContext.Dimension).Reverse())
                .Concat(fungeContext.GetGreatestPoint().Coords(fungeContext.Dimension).Reverse())
                .Append((DateTime.Now.Year - 1900) * 256 * 256 + DateTime.Now.Month * 256 + DateTime.Now.Day)
                .Append(DateTime.Now.Hour * 256 * 256 + DateTime.Now.Minute * 256 + DateTime.Now.Second)
                .Append(fungeContext.CurrentThread.Stacks.Count)
                .Concat(fungeContext.CurrentThread.Stacks.Select(s => s.Count).Reverse()).ToArray();

            if (value > 0)
            {
                if (value > values.Length)
                {
                    fungeContext.PushToTopStack(values[value - values.Length - 1]);
                }
                else
                    fungeContext.PushToTopStack(values[value - 1]);
            }
            else
            {
                foreach (var i in values.Reverse())
                {
                    fungeContext.PushToTopStack(i);
                }
            }


            return null;
        }

        private int GetFlagsInfo(CustomSettings settings)
        {
            int info = 0;
            if (settings.IsConcurrent == OptionStatus.Enable)
            {
                info |= 1;
            }
            if (settings.IsInputFileSupported == OptionStatus.Enable)
            {
                info |= 2;
            }
            if (settings.IsOutputFileSupported == OptionStatus.Enable)
            {
                info |= 4;
            }
            if (settings.IsInputFileSupported == OptionStatus.Enable)
            {
                info |= 8;
            }

            return info;
        }
    }
}
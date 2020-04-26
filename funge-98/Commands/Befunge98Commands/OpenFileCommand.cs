using System.Collections.Generic;
using System.IO;
using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]

    public class OpenFileCommand : ICommand
    {
        public char Name { get; } = 'o';

        public string RealExecute(FungeContext fungeContext)
        {
            var filename = fungeContext.PopString();
            var flag = fungeContext.GetTopStackTopValues(1)[0];
            var va = new DeltaVector(fungeContext.GetTopStackTopValues(fungeContext.Dimension).Reverse().ToArray()) + fungeContext.CurrentThread.StorageOffset;
            var vb = fungeContext.GetTopStackTopValues(fungeContext.Dimension).Reverse().ToArray();
            try
            {
                using var fw = new StreamWriter(File.OpenWrite(filename));


                for (var y = va.Y; y < vb[1] + va.Y; y++)
                {
                    var line = new List<char>();
                    for (var x = va.X; x < va.X + vb[0]; x++)
                    {
                        var c = fungeContext.GetCellValue(new DeltaVector(x, y, 0));
                        line.Add((char) c);
                    }

                    var resString = new string(line.ToArray());
                    if ((flag & 1) == 1)
                    {
                        resString = resString.Trim();
                    }

                    fw.WriteLine(resString);
                }
            }
            catch
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
            }

            return null;
        }
    }
}
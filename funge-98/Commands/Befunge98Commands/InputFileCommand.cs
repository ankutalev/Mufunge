using System;
using System.IO;
using System.Linq;
using Attributes;
using funge_98.ExecutionContexts;

namespace funge_98.Commands.Befunge98Commands
{
    [ContainerElement, Funge98]
    public class InputFileCommand : ICommand
    {
        public char Name { get; } = 'i';

        public string RealExecute(FungeContext fungeContext)
        {
            var filename = fungeContext.PopString();
            var flag = fungeContext.GetTopStackTopValues(1)[0];
            var vec = new DeltaVector(fungeContext.GetTopStackTopValues(fungeContext.Dimension).Reverse().ToArray());
            if (!File.Exists(filename))
            {
                fungeContext.CurrentThreadDeltaVector = fungeContext.CurrentThreadDeltaVector.Reflect();
                return null;
            }

            var y = 0;
            int maxX = 0;
            if ((flag & 1) == 1)
            {
                using var fs = File.OpenRead(filename);
                using var reader = new BinaryReader(fs);
                var target = vec + fungeContext.CurrentThread.StorageOffset;
                while (reader.BaseStream.Position != reader.BaseStream.Length)
                {
                    var c = reader.Read();
                    fungeContext.ModifyCell(target, c);
                    target.X += 1;
                }

                maxX = (int) (reader.BaseStream.Length + fungeContext.CurrentThread.StorageOffset.X);
            }
            else
            {
                foreach (var line in File.ReadLines(filename))
                {
                    for (var x = 0; x < line.Length; x++)
                    {
                        if (line[x] == ' ' || line[x] == '\f')
                            continue;
                        fungeContext.ModifyCell(
                            new DeltaVector(x, y, 0) + vec + fungeContext.CurrentThread.StorageOffset, line[x]);
                    }

                    if (line.Length > maxX)
                    {
                        maxX = line.Length;
                    }

                    y++;
                }
            }


            fungeContext.PushToTopStack(maxX);
            fungeContext.PushToTopStack(y);
            foreach (var c in vec.Coords(fungeContext.Dimension))
            {
                fungeContext.PushToTopStack(c);
            }

            return null;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using funge_98.Exceptions;

namespace funge_98.ExecutionContexts.Fields
{
    public class Befunge93Field : IFungeField
    {
        private readonly int [][] _field;

        public Befunge93Field()
        {
            _field = new int[25][];
            for (var index= 0; index < _field.Length; index++)
            {
                _field[index] = Enumerable.Repeat((int)' ', 80).ToArray();
            }
        }

        public void InitField(IEnumerable<string> source)
        {
            var y = 0;
            foreach (var line in source)
            {
                if (y > 25)
                {
                    throw new IncorrectFileFormatException(
                        "Befunge-93 source code file can contains only 25 lines maximum");
                }

                if (line.Length > 80)
                {
                    throw new IncorrectFileFormatException(
                        "Befunge-93 source code file line can contains only 80 chars");
                }

                for (var x = 0; x < line.Length; x++)
                {
                    _field[y] [x] = line[x];
                }

                y++;
            }
        }

        public void ModifyCell(DeltaVector target, int value)
        {
            _field[target.Y][target.X] = (char) value;
        }


        public int GetValue(DeltaVector dv)
        {
            return IsOutOfBounds(dv) ? 0 : _field[dv.Y][ dv.X];
        }

        public bool IsOutOfBounds(DeltaVector currentPosition)
        {
            return currentPosition.X < 0 || currentPosition.X >= 80 || currentPosition.Y < 0 || currentPosition.Y >= 25;
        }

        public DeltaVector GetLeastPoint()
        {
            throw new NotImplementedException("Not available at Befunge-93");
        }

        public DeltaVector GetGreatestPoint()
        {
            throw new NotImplementedException("Not available at Befunge-93");
        }
    }
}
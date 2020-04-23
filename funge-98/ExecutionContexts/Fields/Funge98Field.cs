using System;
using System.Collections.Generic;

namespace funge_98.ExecutionContexts.Fields
{
    public class Funge98Field : IFungeField
    {
        private readonly Dictionary<int, Dictionary<int, int>> _field = new Dictionary<int, Dictionary<int, int>>();
        private int _maxX;
        private int _maxY;
        private int _minY;
        private int _minX;


        public void InitField(IEnumerable<string> source)
        {
            int y = 0;
            foreach (var line in source)
            {
                for (var x = 0; x < line.Length; x++)
                {
                    var c = line[x];
                    ModifyCell(new DeltaVector(x,y,0), c);
                }
                y++;
            }
        }

        public void ModifyCell(DeltaVector target, int value)
        {
            if (_field.TryGetValue(target.Y, out var xcoords))
            {
                xcoords[target.X] = value;
            }
            else
            {
                _field[target.Y] = new Dictionary<int, int>{ {target.X, value}};
            }

            if (value != ' ')
            {
                _maxX = Math.Max(target.X, _maxX);
                _minX = Math.Min(target.X, _minX);
                _maxY = Math.Max(target.Y, _maxY);
                _minY = Math.Min(target.Y, _minY);
            }
        }    

        public int[] GetMaxCoords()
        {
            return null;
        }

        public int GetValue(DeltaVector dv)
        {
            if (_field.TryGetValue(dv.Y, out var xcoords))
            {
                if (xcoords.TryGetValue(dv.X, out var val))
                    return val;
            }

            return ' ';
        }

        public bool IsOutOfBounds(DeltaVector dv)
        {
            return !(dv.Y <= _maxY && dv.Y >= _minY && dv.X >= _minX && dv.X <= _maxX);
        }

        public DeltaVector GetLeastPoint() => new DeltaVector(_minX,_minY,0);

        public DeltaVector GetGreatestPoint() => new DeltaVector(_maxX,_maxY, 0) + GetLeastPoint().Reflect();

    }
}
using System;
using System.Collections.Generic;

namespace funge_98.ExecutionContexts.Fields
{
    public class TrefungeField : IFungeField
    {
        private readonly Dictionary<int, Dictionary<int, Dictionary<int, int>>> _field =
            new Dictionary<int, Dictionary<int, Dictionary<int, int>>>();

        private int _maxY;
        private int _minY;
        private int _minX;
        private int _maxX;
        private int _minZ;
        private int _maxZ;

        public void InitField(IEnumerable<string> source)
        {
            var y = 0;
            var z = 0;
            var x = 0;
            _field[z] = new Dictionary<int, Dictionary<int, int>>();
            foreach (var line in source)
            {
                _field[z][y] = new Dictionary<int, int>();
                x = 0;
                foreach (var t in line)
                {
                    if (t == 12)
                    {
                        z++;
                        _field[z] = new Dictionary<int, Dictionary<int, int>> {[0] = new Dictionary<int, int>()};
                        y = 0;
                        x = 0;
                        continue;
                    }
                    _field[z][y][x] = t;
                    x++;
                }
                if (line.Length > _maxX)
                {
                    _maxX = line.Length;
                }
                y++;
            }

            _minY = 0;
            _minX = 0;
            _maxY = y;
            _minZ = 0;
            _maxZ = z;
        }

        public void ModifyCell(DeltaVector target, int value)
        {
            if (!_field.TryGetValue(target.Z, out var ycoords))
            {
                _field[target.Z] = new Dictionary<int, Dictionary<int, int>>();
            }

            ycoords = _field[target.Z];
            if (ycoords.TryGetValue(target.Y, out var xcoords))
            {
                xcoords[target.X] = value;
            }
            else
            {
                ycoords[target.Y] = new Dictionary<int, int> {{target.X, value}};
            }

            UpdateBounds();
        }

        public int GetValue(DeltaVector dv)
        {
            if (_field.TryGetValue(dv.Z, out var ycoords))
            {
                if (ycoords.TryGetValue(dv.Y, out var xcoords))
                {
                    if (xcoords.TryGetValue(dv.X, out var val))
                        return val;
                }
            }

            return ' ';
        }

        public bool IsOutOfBounds(DeltaVector dv)
        {
            return !(dv.Y <= _maxY && dv.Y >= _minY && dv.X >= _minX && dv.X <= _maxX && dv.Z <= _maxZ &&
                     dv.Z >= _minZ);
        }

        public DeltaVector GetLeastPoint() => new DeltaVector(_minX, _minY, _minZ);

        public DeltaVector GetGreatestPoint() => new DeltaVector(_maxX, _maxY, _maxZ) + GetLeastPoint().Reflect();

        private void UpdateBounds()
        {
            var maxY = _minY;
            var minY = _maxY;
            var maxX = _minX;
            var minX = _maxX;
            var minZ = _minZ;
            var maxZ = _minZ;

            foreach (var (z, ycoords) in _field)
            {
                foreach (var (y, xcoords) in ycoords)
                {
                    foreach (var (x, v) in xcoords)
                    {
                        if (v != ' ')
                        {
                            if (x < minX)
                                minX = x;
                            else if (x > maxX)
                                maxX = x;
                            if (y < minY)
                                minY = y;
                            else if (y > maxY)
                                maxY = y;
                            if (z < _minZ)
                                minZ = z;
                            else if (z > _maxZ)
                                maxZ = z;
                        }
                    }
                }
            }

            _maxZ = maxZ;
            _minZ = minZ;
            _maxX = maxX;
            _maxY = maxY;
            _minX = minX;
            _minY = minY;
        }
    }
}
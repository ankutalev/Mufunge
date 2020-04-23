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
            int i = 0;
            foreach (var line in source)
            {
                _field[i] = new Dictionary<int, int>();
                for (var j = 0; j < line.Length; j++)
                {
                    _field[i][j] = line[j];
                }

                if (line.Length > _maxX)
                {
                    _maxX = line.Length;
                }

                i++;
            }

            _minY = 0;
            _minX = 0;
            _maxY = i;
        }

        public void ModifyCell(DeltaVector target, int value)
        {
            if (_field.TryGetValue(target.Y, out var xcoords))
            {
                xcoords[target.X] = value;
            }
            else
            {
                _field[target.Y] = new Dictionary<int, int> {{target.X, value}};
            }

            UpdateBounds();
        }

        private void UpdateBounds()
        {
            var maxY = _minY;
            var minY = _maxY;
            var maxX = _minX;
            var minX = _maxX;

            foreach (var (y, xcoords) in _field)
            {
                var yChecked = false;
                foreach (var (x, v) in xcoords)
                {
                    if (v != ' ')
                    {
                        if (x < minX)
                            minX = x;
                        else if (x > maxX)
                            maxX = x;
                        if (!yChecked)
                        {
                            yChecked = true;
                            if (y < minY)
                                minY = y;
                            else if (y > maxY)
                                maxY = y;
                        }
                    }
                }
            }

            _maxX = maxX;
            _maxY = maxY;
            _minX = minX;
            _minY = minY;
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

        public DeltaVector GetLeastPoint() => new DeltaVector(_minX, _minY, 0);

        public DeltaVector GetGreatestPoint() => new DeltaVector(_maxX, _maxY, 0) + GetLeastPoint().Reflect();
    }
}
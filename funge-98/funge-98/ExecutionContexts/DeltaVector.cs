using System.Linq;

namespace funge_98.ExecutionContexts
{
    public class DeltaVector
    {
        private readonly int[] _coords;

        public int X
        {
            get => _coords[0];
            set => _coords[0] = value;
        }

        public int Y
        {
            get => _coords[1];
            set => _coords[1] = value;
        }

        public int Z
        {
            get => _coords[2];
            set => _coords[2] = value;
        }

        public DeltaVector(int x, int y, int z)
        {
            _coords = new[] {x, y, z};
        }

        public DeltaVector(int[] coords)
        {
            _coords = coords;
        }

        public static DeltaVector operator +(DeltaVector a, DeltaVector b)
        {
            return new DeltaVector(a._coords.Zip(b._coords, (f, s) => f + s).ToArray());
        }
    }
}
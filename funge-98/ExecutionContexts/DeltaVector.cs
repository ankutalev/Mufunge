using System.Linq;
using funge_98.Enums;

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

        public DeltaVector Rotate(Direction dir)
        {
            return dir switch
            {
                Direction.EAST => new DeltaVector(-Y, X, Z),
                Direction.WEST => new DeltaVector(Y, -X, Z),
                _ => null
            };
        }

        public DeltaVector Reflect()
        {
            return new DeltaVector(_coords.Select(x=>-x).ToArray());
        }

        public static DeltaVector operator +(DeltaVector a, DeltaVector b)
        {
            return new DeltaVector(a._coords.Zip(b._coords, (f, s) => f + s).ToArray());
        }
    }
}
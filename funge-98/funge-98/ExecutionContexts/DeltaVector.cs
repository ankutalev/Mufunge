namespace funge_98.ExecutionContexts
{
    public class DeltaVector
    {
        public int X { get; }
        public int Y { get; }
        public int Z { get; }

        public DeltaVector(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static DeltaVector operator +(DeltaVector a, DeltaVector b)
        {
            return new DeltaVector(a.X + b.X, a.Y + b.Y, a.Z + a.Z);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using Attributes;

namespace funge_98.ExecutionContexts.Fields
{
    [ContainerElement, Unefunge]
    public class UnefungeField : IFungeField
    {
        private List<char> _field;
        public void InitField(IEnumerable<string> source)
        {
            IEnumerable<char> tmp = new char[0];
            tmp = source.Aggregate(tmp, (current, s) => current.Concat(s.ToCharArray()));

            _field = tmp.ToList();
        }

        public void ModifyCell(DeltaVector target, int value)
        {
            _field[target.X] = (char) value;
        }

        public int GetValue(DeltaVector dv) => _field[dv.X];

        public bool IsOutOfBounds(DeltaVector dv)
        {
            return dv.X < 0 || dv.X >= _field.Count;
        }

        public DeltaVector GetLeastPoint() => new DeltaVector(0, 0, 0);

        public DeltaVector GetGreatestPoint() => new DeltaVector(_field.Count - 1,0,0);
    }
}
using System.Collections;
using System.Collections.Generic;

namespace funge_98.ExecutionContexts.Fields
{
    public interface IFungeField
    {
        void InitField(IEnumerable<string> source);
        void ModifyCell(DeltaVector target, int value);
        int [] GetMaxCoords();
        int GetValue(DeltaVector dv);
        bool IsOutOfBounds(DeltaVector dv);
    }
}
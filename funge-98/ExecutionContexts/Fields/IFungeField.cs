namespace funge_98.ExecutionContexts.Fields
{
    public interface IFungeField
    {
        void ModifyCell(DeltaVector target, int value);
        int [] GetMaxCoords();
        int GetValue();
    }
}
namespace PboneLib.CustomLoading
{
    public interface IContentLoadCondition
    {
        bool Satisfies(CompoundLoadable loadable);
    }
}

namespace PboneLib.CustomLoading.Content
{
    public interface IContentLoadCondition
    {
        bool Satisfies(CompoundLoadable loadable);
    }
}

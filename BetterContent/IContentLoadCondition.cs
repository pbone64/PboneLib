namespace PboneLib.BetterContent
{
    public interface IContentLoadCondition
    {
        bool Satisfies(CompoundLoadable loadable);
    }
}

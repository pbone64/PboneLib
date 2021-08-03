namespace PboneLib.CustomLoading.Conditions
{
    public static class ContentLoad
    {
        public static IContentLoadCondition RespectLoad() => new RespectLoadCondition();
        public class RespectLoadCondition : IContentLoadCondition
        {
            public bool Satisfies(CompoundLoadable loadable) => loadable.AsBetterLoadable.LoadCondition();
        }
    }
}

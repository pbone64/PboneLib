using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalRecipe : GlobalRecipe, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

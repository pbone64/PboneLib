using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalRecipe : GlobalRecipe, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

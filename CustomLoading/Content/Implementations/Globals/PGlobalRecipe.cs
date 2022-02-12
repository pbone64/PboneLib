using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Globals
{
    public abstract class PGlobalRecipe : GlobalRecipe, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

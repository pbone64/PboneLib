using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Globals
{
    public abstract class PGlobalItem : GlobalItem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalItem : GlobalItem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalProjectile : GlobalProjectile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

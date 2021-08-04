using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalProjectile : GlobalProjectile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Globals
{
    public abstract class PGlobalProjectile : GlobalProjectile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

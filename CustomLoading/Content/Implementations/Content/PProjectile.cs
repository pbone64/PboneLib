using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PProjectile : ModProjectile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

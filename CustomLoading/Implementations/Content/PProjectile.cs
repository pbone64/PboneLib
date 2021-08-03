using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PProjectile : ModProjectile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

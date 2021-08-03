using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PPlayer : ModPlayer, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

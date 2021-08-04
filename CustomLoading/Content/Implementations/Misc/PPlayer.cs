using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PPlayer : ModPlayer, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

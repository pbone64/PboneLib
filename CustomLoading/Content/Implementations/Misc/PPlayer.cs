using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PPlayer : ModPlayer, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

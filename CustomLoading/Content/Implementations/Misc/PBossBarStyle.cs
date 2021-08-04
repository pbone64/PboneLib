using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PBossBarStyle : ModBossBarStyle, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

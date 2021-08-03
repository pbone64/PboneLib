using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PBossBarStyle : ModBossBarStyle, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

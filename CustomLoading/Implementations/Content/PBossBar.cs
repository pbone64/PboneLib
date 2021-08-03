using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PBossBar : ModBossBar, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

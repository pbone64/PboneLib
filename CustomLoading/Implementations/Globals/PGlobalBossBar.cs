using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalBossBar : GlobalBossBar, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Globals
{
    public abstract class PGlobalBossBar : GlobalBossBar, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

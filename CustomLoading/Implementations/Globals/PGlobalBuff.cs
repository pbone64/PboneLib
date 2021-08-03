using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalBuff : GlobalBuff, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

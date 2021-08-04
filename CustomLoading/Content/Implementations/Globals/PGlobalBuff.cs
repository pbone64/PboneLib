using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalBuff : GlobalBuff, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PBuff : ModBuff, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

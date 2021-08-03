using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PBuff : ModBuff, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

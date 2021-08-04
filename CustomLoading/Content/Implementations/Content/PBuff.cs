using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public class PBuff : ModBuff, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

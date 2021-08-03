using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PNPC : ModNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

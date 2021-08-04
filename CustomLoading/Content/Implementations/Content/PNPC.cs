using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public class PNPC : ModNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

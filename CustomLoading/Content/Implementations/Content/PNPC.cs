using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PNPC : ModNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

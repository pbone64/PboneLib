using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PNPC : ModNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

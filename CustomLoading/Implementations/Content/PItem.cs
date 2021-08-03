using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PItem : ModItem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

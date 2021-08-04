using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public class PItem : ModItem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PItem : ModItem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

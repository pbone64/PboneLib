using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PTile : ModTile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

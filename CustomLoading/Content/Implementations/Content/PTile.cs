using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public class PTile : ModTile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

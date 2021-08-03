using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PTile : ModTile, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

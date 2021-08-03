using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalTile : GlobalTile, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

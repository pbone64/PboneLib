using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalTile : GlobalTile, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

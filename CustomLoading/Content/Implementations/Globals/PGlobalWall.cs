using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Globals
{
    public abstract class PGlobalWall : GlobalWall, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

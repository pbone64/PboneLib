using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalWall : GlobalWall, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

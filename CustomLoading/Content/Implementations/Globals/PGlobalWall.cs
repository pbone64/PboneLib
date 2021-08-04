using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalWall : GlobalWall, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

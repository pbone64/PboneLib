using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PWall : ModWall, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

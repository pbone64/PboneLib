using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PGlobalNPC : GlobalNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

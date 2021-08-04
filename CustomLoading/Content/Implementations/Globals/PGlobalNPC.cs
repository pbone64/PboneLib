using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PGlobalNPC : GlobalNPC, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

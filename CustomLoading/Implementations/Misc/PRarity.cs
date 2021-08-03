using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PRarity : ModRarity
    {
        public virtual bool LoadCondition() => true;
    }
}

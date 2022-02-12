using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PRarity : ModRarity
    {
        public virtual bool LoadCondition() => true;
    }
}

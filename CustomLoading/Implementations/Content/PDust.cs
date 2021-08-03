using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PDust : ModDust, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

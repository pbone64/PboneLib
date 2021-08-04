using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PDust : ModDust, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

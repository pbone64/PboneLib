using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PPrefix : ModPrefix, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

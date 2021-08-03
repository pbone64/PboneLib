using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PPrefix : ModPrefix, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

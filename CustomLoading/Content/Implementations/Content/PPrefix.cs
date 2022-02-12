using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PPrefix : ModPrefix, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PSystem : ModSystem, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PMenu : ModMenu, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

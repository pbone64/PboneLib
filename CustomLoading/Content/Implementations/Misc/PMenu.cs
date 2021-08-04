using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PMenu : ModMenu, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

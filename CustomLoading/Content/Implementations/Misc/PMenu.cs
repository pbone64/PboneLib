using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PMenu : ModMenu, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

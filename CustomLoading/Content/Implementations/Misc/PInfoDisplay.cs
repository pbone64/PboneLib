using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PInfoDisplay : InfoDisplay, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

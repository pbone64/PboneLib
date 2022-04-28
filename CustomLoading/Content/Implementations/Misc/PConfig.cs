using Terraria.ModLoader.Config;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PConfig : ModConfig, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;

        public abstract string GetName();
    }
}

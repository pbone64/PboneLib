using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PSceneEffect : ModSceneEffect, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

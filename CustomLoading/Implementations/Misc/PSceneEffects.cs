using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PSceneEffect : ModSceneEffect, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

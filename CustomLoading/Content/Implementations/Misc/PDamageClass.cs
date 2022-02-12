using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PDamageClass : DamageClass, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

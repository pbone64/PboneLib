using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PDamageClass : DamageClass, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PDamageClass : DamageClass, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

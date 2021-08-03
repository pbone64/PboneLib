using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public class PGore : ModGore, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

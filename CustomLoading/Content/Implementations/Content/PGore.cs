using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public class PGore : ModGore, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

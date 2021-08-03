using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PCommand : ModCommand, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

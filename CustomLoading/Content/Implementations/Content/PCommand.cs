using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    public abstract class PCommand : ModCommand, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

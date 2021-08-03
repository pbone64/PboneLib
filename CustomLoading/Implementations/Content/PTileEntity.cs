using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Implementations
{
    public abstract class PTileEntity : ModTileEntity, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

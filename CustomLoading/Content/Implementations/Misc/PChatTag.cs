using PboneLib.CustomModTypes;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PChatTag : ModChatTag, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

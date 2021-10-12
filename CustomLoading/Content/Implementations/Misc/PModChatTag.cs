using PboneLib.CustomModTypes;

namespace PboneLib.CustomLoading.Content.Implementations
{
    public abstract class PModChatTag : ModChatTag, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

using PboneLib.CustomModTypes;

namespace PboneLib.CustomLoading.Content.Implementations.Misc
{
    public abstract class PModChatTag : ModChatTag, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

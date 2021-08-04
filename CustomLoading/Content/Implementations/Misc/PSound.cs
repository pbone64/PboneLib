using System;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations
{
    [Obsolete("Sounds are a separate system not supported by custom loading.")]
    public abstract class PSound : ModSound, ICustomLoadable
    {
        public bool LoadCondition() => true;
    }
}

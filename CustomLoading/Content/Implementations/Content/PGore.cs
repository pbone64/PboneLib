using System;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content.Implementations.Content
{
    [Obsolete("Gores are a separate system not supported by custom loading.")]
    public abstract class PGore : ModGore, ICustomLoadable
    {
        public virtual bool LoadCondition() => true;
    }
}

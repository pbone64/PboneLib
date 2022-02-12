using Microsoft.Xna.Framework.Graphics;
using PboneLib.CustomLoading.Content.Implementations.Misc;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace PboneLib.Services.Textures
{
    public abstract class ModTextureManager : PSystem
    {
        public Texture2D this[string name] { get => (GetAsset(name) as Asset<Texture2D>).Value; }

        public Dictionary<string, IAsset> CachedAssets;

        public abstract Dictionary<string, string> GetImmediateTextures();
        public abstract Dictionary<string, string> GetOtherTextures();

        public override void Load()
        {
            base.Load();

            CachedAssets = new Dictionary<string, IAsset>();
            foreach (KeyValuePair<string, string> s in GetImmediateTextures())
            {
                CachedAssets.Add(s.Key, ModContent.Request<Texture2D>(s.Value, AssetRequestMode.ImmediateLoad));
            }
        }

        public override void Unload()
        {
            base.Unload();

            foreach (KeyValuePair<string, IAsset> cache in CachedAssets)
            {
                Main.QueueMainThreadAction(() => {
                    cache.Value.Dispose();
                });
            }

            // This needs to bbe queued on the main thread so it happens _after_ the cache is disposed
            Main.QueueMainThreadAction(() => {
                CachedAssets.Clear();
            });
        }

        public Asset<Texture2D> GetAsset(string name)
        {
            if (CachedAssets.TryGetValue(name, out IAsset asset))
                return asset as Asset<Texture2D>;

            CachedAssets.Add(name, ModContent.Request<Texture2D>(GetOtherTextures()[name]));
            return CachedAssets[name] as Asset<Texture2D>;
        }
    }
}

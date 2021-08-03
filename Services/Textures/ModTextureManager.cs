using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using System.Collections.Generic;
using Terraria.ModLoader;

namespace PboneLib.Services.Textures
{
    public abstract class ModTextureManager : ModSystem
    {
        public IAsset this[string name] { get => GetAsset(name); }

        public Dictionary<string, IAsset> CachedAssets;

        public abstract Dictionary<string, string> GetImmediateTextures();
        public abstract Dictionary<string, string> GetOtherTextures();

        public override void Load()
        {
            base.Load();

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
                cache.Value.Dispose();
            }

            CachedAssets.Clear();
        }

        public IAsset GetAsset(string name)
        {
            if (CachedAssets.TryGetValue(name, out IAsset asset))
                return asset;

            CachedAssets.Add(name, ModContent.Request<Texture2D>(GetOtherTextures()[name]));
            return CachedAssets[name];
        }
    }
}

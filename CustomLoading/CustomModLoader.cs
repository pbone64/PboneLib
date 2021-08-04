using System.Collections.Generic;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading
{
    public class CustomModLoader
    {
        public Mod Mod;
        public List<ICustomLoader> Loaders;

        public CustomModLoader(Mod mod)
        {
            Mod = mod;
            Loaders = new List<ICustomLoader>();
        }

        public void Load()
        {
            foreach (ICustomLoader loader in Loaders)
                loader.Load(Mod);
        }

        public void Add<T>() where T : ICustomLoader, new() => Loaders.Add(new T());
    }
}

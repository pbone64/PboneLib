using System.Collections.Generic;
using Terraria.ModLoader;

namespace PboneLib.Core.CrossMod.Ref
{
    public class ModRefManager
    {
        public Mod Mod;

        public Dictionary<string, IModCompatibility> ModCompatabilitiesByMod;

        public void Load()
        {
            ModCompatabilitiesByMod = new Dictionary<string, IModCompatibility>();
        }

        public IModCompatibility GetModCompatibility(string mod) => ModCompatabilitiesByMod[mod];
        public Mod GetMod(string mod) => GetModCompatibility(mod).GetMod();
        public bool IsModLoaded(string mod) => GetModCompatibility(mod).IsLoaded();

        public void RegisterCompatibility<T>() where T : IModCompatibility, new()
        {
            IModCompatibility compatibility = new T();
            ModCompatabilitiesByMod.Add(compatibility.GetModName(), compatibility);
        }
    }
}

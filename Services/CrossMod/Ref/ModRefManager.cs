using System.Collections.Generic;
using Terraria.ModLoader;

namespace PboneLib.Services.CrossMod.Ref
{
    public class ModRefManager
    {
        public Dictionary<string, IModCompatibility> ModCompatabilitiesByMod;

        public ModRefManager()
        {
            ModCompatabilitiesByMod = new Dictionary<string, IModCompatibility>();
        }

        public IModCompatibility GetModCompatibility(string mod) => ModCompatabilitiesByMod[mod];
        public Mod GetMod(string mod) => GetModCompatibility(mod).GetMod();
        public bool IsModLoaded(string mod) => GetModCompatibility(mod).IsLoaded();

        public void Load()
        {
            foreach (KeyValuePair<string, IModCompatibility> kvp in ModCompatabilitiesByMod)
            {
                if (kvp.Value.IsLoaded())
                    kvp.Value.Load();
            }
        }

        public void RegisterCompatibility<T>() where T : IModCompatibility, new()
        {
            IModCompatibility compatibility = new T();
            ModCompatabilitiesByMod.Add(compatibility.GetModName(), compatibility);
        }
    }
}

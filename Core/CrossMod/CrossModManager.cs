using PboneLib.Core.CrossMod.Call;
using PboneLib.Core.CrossMod.Ref;
using Terraria.ModLoader;

namespace PboneLib.Core.CrossMod
{
    public class CrossModManager
    {
        public Mod Mod;

        public ModCallManager CallManager;
        public ModRefManager RefManager;

        public CrossModManager(Mod mod)
        {
            Mod = mod;

            CallManager = new ModCallManager(mod);
            RefManager = new ModRefManager(mod);
        }

        public T GetModCompatibility<T>(string mod) where T : IModCompatibility => (T)RefManager.GetModCompatibility(mod);
        public Mod GetMod(string mod) => RefManager.GetModCompatibility(mod).GetMod();
        public bool IsModLoaded(string mod) => RefManager.GetModCompatibility(mod).IsLoaded();
    }
}

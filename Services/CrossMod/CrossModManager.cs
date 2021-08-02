using PboneLib.Services.CrossMod.Call;
using PboneLib.Services.CrossMod.Ref;
using Terraria.ModLoader;

namespace PboneLib.Services.CrossMod
{
    public class CrossModManager
    {
        public ModCallManager CallManager;
        public ModRefManager RefManager;

        public CrossModManager()
        {
            CallManager = new ModCallManager();
            RefManager = new ModRefManager();
        }

        public IModCompatibility GetModCompatibility(string mod) => RefManager.GetModCompatibility(mod);
        public T GetModCompatibility<T>(string mod) where T : IModCompatibility => (T)GetModCompatibility(mod);
        public Mod GetMod(string mod) => GetModCompatibility(mod).GetMod();
        public bool IsModLoaded(string mod) => GetModCompatibility(mod).IsLoaded();
    }
}

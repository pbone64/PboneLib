using Terraria.ModLoader;

namespace PboneLib.Services.CrossMod.Ref
{
    public interface IModCompatibility
    {
        bool IsLoaded();
        Mod GetMod();
        string GetModName();
        void Load();
    }
}

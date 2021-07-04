using Terraria.ModLoader;

namespace PboneLib.Core.CrossMod.Ref
{
    public interface IModCompatibility
    {
        bool IsLoaded();
        Mod GetMod();
        string GetModName();
    }
}

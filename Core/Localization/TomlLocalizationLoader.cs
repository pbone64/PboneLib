using System.Threading;
using Terraria.ModLoader;

namespace PboneLib.Core.Localization
{
    public class TomlLocalizationLoader
    {
        public Mod Mod;

        public TomlLocalizationLoader(Mod mod)
        {
            Mod = mod;
        }

        public void LoadTranslations()
        {
            string currentLanguageId = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName; // Like en-US, en-ES...
            string fullPath = $"{Mod.Name}/Localization/{currentLanguageId}.toml";

            byte[] bytes = Mod.GetFileBytes(fullPath);
        }
    }
}

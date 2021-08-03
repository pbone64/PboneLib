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
            /*string currentLanguageId = Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName; // Like en-US, en-ES...
            string fullPath = $"{Mod.Name}/Localization/{currentLanguageId}.toml";

            List<TomlDocument> docs = new List<TomlDocument>();
            TomlParser parser = new TomlParser();
            using (StreamReader reader = new StreamReader(Mod.GetFileStream(fullPath)))
            {
                docs.Add(parser.Parse(reader.ReadToEnd()));
            }*/

            foreach (string asset in Mod.RootContentSource.EnumerateAssets())
            {
                Mod.Logger.Info(asset);
            }
        }
    }
}

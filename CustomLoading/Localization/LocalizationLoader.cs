using MonoMod.Utils;
using PboneLib.CustomLoading.Localization.Parsers;
using PboneLib.DataStructures;
using PboneLib.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

namespace PboneLib.CustomLoading.Localization
{
    public class LocalizationLoader : ICustomLoader
    {
        public struct LocalizationLoaderSettings
        {
            public Dictionary<string, ILocalizationFileParser> ExtensionsToParsers;

            public Action<ModTranslation> AddTranslationAction;

            public LocalizationLoaderSettings(Action<ModTranslation> addTranslationAction)
            {
                ExtensionsToParsers = new Dictionary<string, ILocalizationFileParser>();

                AddTranslationAction = addTranslationAction;
            }

            public void FillWithDefaultParsers()
            {
                ExtensionsToParsers.AddRange(new Dictionary<string, ILocalizationFileParser> {
                    ["lang"] = new LangFileParser(),
                    ["toml"] = new TomlFileParser()
                });
            }
        }

        public LocalizationLoaderSettings Settings;

        public LocalizationLoader(Action<ModTranslation> addTranslationAction)
        {
            Settings = new LocalizationLoaderSettings(addTranslationAction);
            Settings.FillWithDefaultParsers();
        }

        public void Load(Mod mod)
        {
            IEnumerable<KeyValuePair<string, TmodFile.FileEntry>> localizationFiles = mod.GetAllFiles()
                .Where(kvp => {
                    // Format: en-US.extension
                    string[] splitText = SplitFilePath(kvp.Key);
                    if (splitText.Length != 2)
                        return false;

                    if (!MiscUtils.IsValidCulture(splitText[0])
                     || !Settings.ExtensionsToParsers.Keys.Contains(splitText[2]))
                        return false;

                    return true;
                });

            ModTranslationCollection translations = new ModTranslationCollection();
            foreach (KeyValuePair<string, TmodFile.FileEntry> kvp in localizationFiles)
            {
                using (Stream s = mod.GetFileStream(kvp.Key))
                {
                    string[] splitText = SplitFilePath(kvp.Key);
                    string culture = splitText[0];
                    string ext = splitText[1];

                    ILocalizationFileParser parser = Settings.ExtensionsToParsers[ext];
                    translations.Merge(parser.ParseStream(mod, culture, s));
                }
            }

            foreach (KeyValuePair<string, ModTranslation> kvp in translations.Translations)
                Settings.AddTranslationAction(kvp.Value);
        }

        private static string[] SplitFilePath(string path) =>
            path.Split('/').Last().Split('.');
    }
}

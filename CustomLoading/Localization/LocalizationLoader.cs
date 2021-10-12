using MonoMod.Utils;
using PboneLib.CustomLoading.Localization.Parsers;
using PboneLib.DataStructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.ModLoader;

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
            IEnumerable<string> localizationFiles = mod.GetFileNames()
                .Where(file => {
                    // Format: en-US.extension
                    string[] splitText = SplitFilePath(file);
                    if (splitText.Length != 2)
                        return false;

                    if (!Settings.ExtensionsToParsers.ContainsKey(splitText[1]))
                        return false;

                    return true;
                });

            ModTranslationCollection translations = new ModTranslationCollection();
            foreach (string file in localizationFiles)
            {
                using (Stream s = mod.GetFileStream(file))
                {
                    string[] splitText = SplitFilePath(file);
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

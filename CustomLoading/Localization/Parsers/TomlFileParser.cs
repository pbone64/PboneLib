using System.Collections.Generic;
using Terraria.ModLoader;
using Tomlet;
using Tomlet.Models;
using TModLocalizationLoader = Terraria.ModLoader.LocalizationLoader;

namespace PboneLib.CustomLoading.Localization.Parsers
{
    public class TomlFileParser : ILocalizationFileParser
    {
        public IDictionary<string, ModTranslation> ParseText(Mod mod, string culture, string text)
        {
            TomlDocument document = new TomlParser().Parse(text);
            Dictionary<string, ModTranslation> dictionary = new Dictionary<string, ModTranslation>();
            foreach (KeyValuePair<string, TomlValue> kvp in document.Entries)
            {
                string key = kvp.Key;
                string value = kvp.Value.StringValue;
                value = value.Replace("\\n", "\n");

                if (!dictionary.TryGetValue(key, out var translation))
                {
                    translation = (dictionary[key] = TModLocalizationLoader.CreateTranslation(mod, key));
                }
                translation.AddTranslation(culture, value);
            }

            return dictionary;
        }
    }
}

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
                GetValues(kvp.Key, kvp.Value, out IDictionary<string, string> values);

                foreach (KeyValuePair<string, string> tr in values)
                {
                    string key = tr.Key;
                    string value = tr.Value;
                    value = value.Replace("\\n", "\n");

                    if (!dictionary.TryGetValue(key, out var translation))
                    {
                        translation = (dictionary[key] = TModLocalizationLoader.CreateTranslation(mod, key));
                    }
                    translation.AddTranslation(culture, value);
                }
            }

            return dictionary;
        }

        public void GetValues(string key, TomlValue toml, out IDictionary<string, string> values)
        {
            if (toml is TomlTable table)
            {
                values = new Dictionary<string, string>();

                foreach (KeyValuePair<string, TomlValue> kvp in table.Entries)
                {
                    GetValues(kvp.Key, kvp.Value, out values);
                }

                return;
            }

            values = new Dictionary<string, string> {
                [key] = toml.StringValue
            };
        }
    }
}

using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader;
using TModLocalizationLoader = Terraria.ModLoader.LocalizationLoader;

namespace PboneLib.CustomLoading.Localization.Parsers
{
    public class LangFileParser : ILocalizationFileParser
    {
        public IDictionary<string, ModTranslation> ParseText(Mod mod, string culture, string text)
        {
            using StringReader reader = new StringReader(text);
            Dictionary<string, ModTranslation> dictionary = new Dictionary<string, ModTranslation>();

            // From LocalizationLoader.Autoload
            while ((text = reader.ReadLine()) != null)
            {
                int num = text.IndexOf('=');
                if (num < 0)
                {
                    continue;
                }
                string key = text.Substring(0, num).Trim().Replace(" ", "_");
                string value = text[(num + 1)..];

                if (value.Length != 0)
                {
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
    }
}

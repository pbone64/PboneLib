using System.Collections.Generic;
using System.IO;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Localization
{
    public interface ILocalizationFileParser
    {
        IDictionary<string, ModTranslation> ParseStream(Mod mod, string culture, Stream stream)
        {
            using StreamReader reader = new StreamReader(stream);
            return ParseText(mod, culture, reader.ReadToEnd());
        }

        IDictionary<string, ModTranslation> ParseText(Mod mod, string culture, string text);
    }
}

using System.Collections.Generic;
using System.IO;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Localization
{
    public interface ILocalizationFileParser
    {
        IDictionary<string, LocalizedText> ParseStream(Mod mod, string culture, Stream stream)
        {
            using StreamReader reader = new StreamReader(stream);
            return ParseText(mod, culture, reader.ReadToEnd());
        }

        IDictionary<string, LocalizedText> ParseText(Mod mod, string culture, string text);
    }
}

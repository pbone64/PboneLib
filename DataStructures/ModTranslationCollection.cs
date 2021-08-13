using System.Collections.Generic;
using System.Reflection;
using Terraria.ModLoader;

namespace PboneLib.DataStructures
{
    public class ModTranslationCollection
    {
        public static FieldInfo ModTranslation_translations = typeof(ModTranslation).GetField("translations", BindingFlags.Instance | BindingFlags.NonPublic);

        public Dictionary<string, ModTranslation> Translations;

        public ModTranslationCollection()
        {
            Translations = new Dictionary<string, ModTranslation>();
        }

        public ModTranslation GetOrCreateTranslation(Mod mod, string key, bool add = false) => GetOrCreateTranslation("Mods." + mod.Name + "." + key, add);
        public ModTranslation GetOrCreateTranslation(string key, bool add = false)
        {
            key = key.Replace(" ", "_");
            if (Translations.TryGetValue(key, out var value))
            {
                return value;
            }

            ModTranslation translation = LocalizationLoader.CreateTranslation(key);

            if (add)
                Translations.Add(key, translation);

            return translation;
        }

        // Slow
        public void Merge(ModTranslationCollection other) => Merge(other.Translations);
        public void Merge(IDictionary<string, ModTranslation> other)
        {
            foreach (KeyValuePair<string, ModTranslation> kvp in other)
            {
                ModTranslation translation = GetOrCreateTranslation(kvp.Key, true);

                Dictionary<int, string> existingTranslations = ModTranslation_translations.GetValue(translation) as Dictionary<int, string>;
                Dictionary<int, string> newTranslations = ModTranslation_translations.GetValue(kvp.Value) as Dictionary<int, string>;
                foreach (KeyValuePair<int, string> tr in newTranslations)
                {
                    // For each translation the merged collection's ModTranslation has
                    if (existingTranslations.ContainsKey(tr.Key)) // If the translation already has the specified translations
                    {
                        translation.AddTranslation(kvp.Key, kvp.Value.GetTranslation(tr.Key)); // Though it's called AddTranslation, it's basically an AddOrSetTranslation
                    }
                }

                Translations[kvp.Key] = translation;
            }
        }
    }
}

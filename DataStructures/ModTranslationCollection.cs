using System.Collections.Generic;
using System.Linq;
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
                // Get the translation that currently exists in this collection
                ModTranslation translation = GetOrCreateTranslation(kvp.Key, true);

                Dictionary<int, string> newTranslations = ModTranslation_translations.GetValue(kvp.Value) as Dictionary<int, string>;

                // For each translation in the equivelent ModTranslation's translations...
                foreach (KeyValuePair<int, string> tr in newTranslations)
                {
                    // NOTE: ModTranslations ALWAYS have an en-US translations, which by default is the key
                    // This check makes sure you aren't setting the en-US translation to a fallback value
                    if (tr.Value == null || tr.Value.EndsWith(translation.Key))
                        continue;

                    // Add it to the current translation
                    Translations[kvp.Key].AddTranslation(tr.Key, tr.Value); // Though it's called AddTranslation, it's basically an AddOrSetTranslation
                }
            }
        }
    }
}

using PboneLib.CustomLoading.Content.Conditions;
using System;
using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;

namespace PboneLib.CustomLoading.Content
{
    public class ContentLoader : ICustomLoader
    {
        public struct ContentLoaderSettings
        {
            public List<ITryToLoadCondition> TryToLoadConditions;
            public List<IContentLoadCondition> LoadConditions;

            public Action<CompoundLoadable> LoadAction;

            public ContentLoaderSettings(Action<CompoundLoadable> loadAction)
            {
                LoadConditions = new List<IContentLoadCondition>();
                TryToLoadConditions = new List<ITryToLoadCondition>();

                LoadAction = loadAction;
            }

            public void FillWithDefaultConditions()
            {
                TryToLoadConditions.AddRange(new List<ITryToLoadCondition> {
                    TryToLoad.IsNotAbstract(),
                    TryToLoad.DoesNotContainGenericParameters(),
                    TryToLoad.HasZeroParameterConstructor(),
                    TryToLoad.IsNotType<Mod>(),
                    TryToLoad.ImplementsInterface<ILoadable>(),
                    TryToLoad.ImplementsInterface<ICustomLoadable>()
                });

                LoadConditions.AddRange(new List<IContentLoadCondition> {
                    ContentLoad.RespectLoad()
                });
            }

            public bool TypeSatisfies(Type type) => TryToLoadConditions.TrueForAll(condition => condition.Satisfies(type));
            public bool ContentSatisfies(CompoundLoadable content) => LoadConditions.TrueForAll(condition => condition.Satisfies(content));
        }

        public ContentLoaderSettings Settings;

        public ContentLoader(Action<CompoundLoadable> loadAction)
        {
            Settings = new ContentLoaderSettings(loadAction);
            Settings.FillWithDefaultConditions();
        }

        public ContentLoader(ContentLoaderSettings settings)
        {
            Settings = settings;
        }

        public void Load(Mod mod)
        {
            // Ordering for parity with tML loading
            foreach (Type type in mod.Code.GetTypes().OrderBy(t => t.FullName, StringComparer.InvariantCulture))
            {
                TryLoadGenericContent(type);
            }
        }

        public bool TryLoadGenericContent(Type type)
        {
            if (Settings.TypeSatisfies(type))
            {
                CompoundLoadable content = new CompoundLoadable(Activator.CreateInstance(type));

                if (Settings.ContentSatisfies(content))
                {
                    Settings.LoadAction(content);
                    return true;
                }
            }

            return false;
        }
    }
}

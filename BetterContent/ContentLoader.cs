using PboneLib.BetterContent.Conditions;
using System;
using System.Collections.Generic;

namespace PboneLib.BetterContent
{
    public class ContentLoader
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
                    TryToLoad.ImplementsProperInterfaces()
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

        public void LoadFromTypes(Type[] types)
        {
            foreach (Type type in types)
            {
                if (Settings.TypeSatisfies(type))
                {
                    CompoundLoadable content = new CompoundLoadable(Activator.CreateInstance(type));

                    if (Settings.ContentSatisfies(content))
                    {
                        Settings.LoadAction(content);
                    }
                }
            }
        }
    }
}

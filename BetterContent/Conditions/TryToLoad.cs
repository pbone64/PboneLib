using PboneLib.Utils;
using System;
using Terraria.ModLoader;

namespace PboneLib.BetterContent.Conditions
{
    public static class TryToLoad
    {
        public static ITryToLoadCondition IsNotAbstract() => new IsNotAbstractCondition();
        public class IsNotAbstractCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => !type.IsAbstract;
        }

        public static ITryToLoadCondition ImplementsProperInterfaces() => new ImplementsProperInterfacesCondition();
        public class ImplementsProperInterfacesCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => type.Implements<ILoadable>() && type.Implements<IBetterLoadable>();
        }
    }
}

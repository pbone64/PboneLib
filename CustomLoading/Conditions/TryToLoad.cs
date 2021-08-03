using PboneLib.Utils;
using System;

namespace PboneLib.CustomLoading.Conditions
{
    public static class TryToLoad
    {
        public static ITryToLoadCondition IsNotAbstract() => new IsNotAbstractCondition();
        public class IsNotAbstractCondition : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => !type.IsAbstract;
        }

        public static ITryToLoadCondition ImplementsInterface<T>() => new ImplementsInterfaceCondition<T>();
        public class ImplementsInterfaceCondition<T> : ITryToLoadCondition
        {
            public bool Satisfies(Type type) => type.Implements<T>();
        }
    }
}

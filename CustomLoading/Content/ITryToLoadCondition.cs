using System;

namespace PboneLib.CustomLoading.Content
{
    public interface ITryToLoadCondition
    {
        public bool Satisfies(Type type);
    }
}

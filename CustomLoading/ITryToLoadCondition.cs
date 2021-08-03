using System;

namespace PboneLib.CustomLoading
{
    public interface ITryToLoadCondition
    {
        public bool Satisfies(Type type);
    }
}

using System;

namespace PboneLib.BetterContent
{
    public interface ITryToLoadCondition
    {
        public bool Satisfies(Type type);
    }
}

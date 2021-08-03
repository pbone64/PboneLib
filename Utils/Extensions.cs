using System;
using System.Linq;

namespace PboneLib.Utils
{
    public static class Extensions
    {
        public static bool Implements<T>(this Type type) => type.GetInterfaces().Contains(typeof(T));
    }
}

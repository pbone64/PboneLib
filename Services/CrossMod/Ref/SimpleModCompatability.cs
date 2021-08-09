using System;
using System.Reflection;
using Terraria.ModLoader;

namespace PboneLib.Services.CrossMod.Ref
{
    public abstract class SimpleModCompatibility : IModCompatibility
    {
        public bool IsModLoaded => Mod != null;
        public readonly Mod Mod;
        public readonly string ModName;

        protected SimpleModCompatibility()
        {
            ModRefAttribute attribute = GetType().GetCustomAttribute<ModRefAttribute>();
            if (attribute == null)
                return;

            ModLoader.TryGetMod(attribute.Mod, out Mod mod);
            Mod = mod;
            ModName = attribute.Mod;
        }

        public virtual void Load() { }

        public Mod GetMod() => Mod;
        public bool IsLoaded() => IsModLoaded;
        public string GetModName() => ModName;
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class ModRefAttribute : Attribute
    {
        public readonly string Mod;

        public ModRefAttribute(string mod)
        {
            Mod = mod;
        }
    }
}
using System;
using System.Reflection;
using Terraria.ModLoader;

namespace PboneLib.Services.CrossMod.Ref
{
    public abstract class SimpleModCompatibility : IModCompatibility
    {
        private bool IsModLoaded => Mod != null;
        private readonly Mod Mod;
        private readonly string ModName;

        protected SimpleModCompatibility()
        {
            ModRefAttribute attribute = GetType().GetCustomAttribute<ModRefAttribute>();
            if (attribute == null)
                return;

            Mod = ModLoader.GetMod(attribute.Mod);
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
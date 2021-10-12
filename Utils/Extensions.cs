using PboneLib.CustomLoading.Content;
using System;
using System.Linq;
using System.Reflection;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.Core;

namespace PboneLib.Utils
{
    public static class Extensions
    {
        public static PropertyInfo Mod_File = typeof(Mod).GetProperty("File", BindingFlags.NonPublic | BindingFlags.Instance);
        public static FieldInfo TmodFile_files = typeof(TmodFile).GetField("files", BindingFlags.NonPublic | BindingFlags.Instance);

        public static bool IsVanilla(this Item item) => item.type < ItemID.Count;
        public static bool IsModded(this Item item) => !item.IsVanilla();

        public static void TryIncreaseMaxStack(this Item item, int newStack)
        {
            if (item.maxStack < newStack)
            {
                item.maxStack = newStack;
            }
        }

        public static void AddShopItem(this Chest shop, int item, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(item);
            nextSlot++;
        }

        public static bool Implements<T>(this Type type) => type.GetInterfaces().Contains(typeof(T));

        public static void AddContent(this Mod mod, CompoundLoadable content) => mod.AddContent(content.AsLoadable);
    }
}

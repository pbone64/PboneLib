using System;
using System.Linq;

namespace PboneLib.Utils
{
    public static class Extensions
    {
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
    }
}

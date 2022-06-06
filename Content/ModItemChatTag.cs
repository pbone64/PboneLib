using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using PboneLib.CustomModTypes;
using ReLogic.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.GameContent.UI;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.UI;
using Terraria.UI.Chat;
using Terraria.ID;

namespace PboneLib.Content
{
    public class ModItemChatTag : ModChatTag
    {
        public override string[] Names => new string[] { "mi" };
        
        public override TextSnippet Parse(string text, Color baseColor = default, string options = null)
        {
            Item item = new();

            string[] itemText = text.Split('.');
            if (itemText.Length == 2)
            {
                Mod mod = ModLoader.GetMod(itemText[0]);
                if (mod != null)
                {
                    if (mod.TryFind(itemText[1], out ModItem instance))
                        item.netDefaults(instance.Type);
                }
            }

            if (item.type == ItemID.None)
                item.netDefaults(1);

            if (item.type <= ItemID.None)
                return new TextSnippet(text);

            item.stack = 1;
            if (options != null)
            {
                string[] array = options.Split(',');
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].Length == 0)
                        continue;

                    switch (array[i][0])
                    {
                        case 'd': // MID is present, we will override
                            item = ItemIO.FromBase64(array[i].Substring(1));
                            break;
                        case 's':
                        case 'x':
                            {
                                if (int.TryParse(array[i].Substring(1), out int result3))
                                    item.stack = Terraria.Utils.Clamp(result3, 1, item.maxStack);

                                break;
                            }
                        case 'p':
                            {
                                if (int.TryParse(array[i].Substring(1), out int result2))
                                    item.Prefix((byte)Terraria.Utils.Clamp(result2, 0, PrefixLoader.PrefixCount));

                                break;
                            }
                    }
                }
            }

            string str = "";
            if (item.stack > 1)
                str = " (" + item.stack + ")";

            return new ItemSnippet(item) {
                Text = "[" + item.AffixName() + str + "]",
                CheckForHover = true,
                DeleteWhole = true
            };
        }
    }

    // Literally just vanilla ItemSnippet but public
    public class ItemSnippet : TextSnippet
    {
        private Item _item;

        public ItemSnippet(Item item)
        {
            _item = item;
            Color = ItemRarity.GetColor(item.rare);
        }

        public override void OnHover()
        {
            Main.HoverItem = _item.Clone();
            Main.instance.MouseText(_item.Name, _item.rare, 0);
        }

        //TODO possibly allow modders to custom draw here
        public override bool UniqueDraw(bool justCheckingString, out Vector2 size, SpriteBatch spriteBatch, Vector2 position = default(Vector2), Color color = default(Color), float scale = 1f)
        {
            float num = 1f;
            float num2 = 1f;
            if (Main.netMode != 2 && !Main.dedServ)
            {
                Main.instance.LoadItem(_item.type);
                Texture2D value = TextureAssets.Item[_item.type].Value;
                if (Main.itemAnimations[_item.type] != null)
                    Main.itemAnimations[_item.type].GetFrame(value);
                else
                    value.Frame();
            }

            num2 *= scale;
            num *= num2;
            if (num > 0.75f)
                num = 0.75f;

            if (!justCheckingString && color != Color.Black)
            {
                float inventoryScale = Main.inventoryScale;
                Main.inventoryScale = scale * num;
                ItemSlot.Draw(spriteBatch, ref _item, 14, position - new Vector2(10f) * scale * num, Color.White);
                Main.inventoryScale = inventoryScale;
            }

            size = new Vector2(32f) * scale * num;
            return true;
        }

        public override float GetStringLength(DynamicSpriteFont font) => 32f * Scale * 0.65f;
    }

}

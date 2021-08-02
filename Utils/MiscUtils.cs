using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;

namespace PboneLib.Utils
{
    public static class MiscUtils
    {
        public static void NewTextSynced(object text, Color color)
        {
            if (Main.netMode == NetmodeID.SinglePlayer)
                Main.NewText(text, color);
            else
                ChatHelper.BroadcastChatMessage(NetworkText.FromLiteral(text.ToString()), color);
        }

        public static bool AnyBoss()
        {
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && (Main.npc[i].boss || NPCID.Sets.ShouldBeCountedAsBoss[Main.npc[i].type]))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsTargetTileInItemRange(this Player player, Item item)
        {
            if (player.position.X / 16f - Player.tileRangeX - item.tileBoost <= Player.tileTargetX && (player.position.X + player.width) / 16f + Player.tileRangeX + item.tileBoost - 1f >= Player.tileTargetX && player.position.Y / 16f - Player.tileRangeY - item.tileBoost <= Player.tileTargetY)
                return (player.position.Y + player.height) / 16f + Player.tileRangeY + item.tileBoost - 2f >= Player.tileTargetY;

            return false;
        }
    }
}

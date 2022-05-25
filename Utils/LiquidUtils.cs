using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace PboneLib.Utils
{
    public static class LiquidHelper
    {
        public static bool PlaceLiquid(int x, int y, byte type)
        {
            Tile tile = Framing.GetTileSafely(x, y);

            if (tile.LiquidAmount == 0 || tile.LiquidType == type)
            {
                SoundEngine.PlaySound(SoundID.Splash, new Vector2(x, y));
                tile.LiquidType = type;
                tile.LiquidAmount = byte.MaxValue;
                WorldGen.SquareTileFrame(x, y);

                if (Main.netMode == NetmodeID.MultiplayerClient)
                    NetMessage.sendWater(x, y);

                return true;
            }

            return false;
        }

        public static bool DrainLiquid(int x, int y, byte type)
        {
            int targettedLiquid = Main.tile[x, y].LiquidAmount;
            int nearbyLiquid = 0;
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (Main.tile[i, j].LiquidType == targettedLiquid)
                        nearbyLiquid += Main.tile[i, j].LiquidAmount;
                }
            }

            if (Main.tile[x, y].LiquidAmount <= 0)
                return false;

            int liquidType = Main.tile[x, y].LiquidType;
            int liquidAmount = Main.tile[x, y].LiquidAmount;

            if (liquidType != type)
                return false;

            Main.tile[x, y].LiquidAmount = 0;
            Tile tile = Main.tile[x, y];
            tile.LiquidType = 0;

            WorldGen.SquareTileFrame(x, y, resetFrame: false);

            if (Main.netMode == NetmodeID.MultiplayerClient)
                NetMessage.sendWater(x, y);
            else
                Liquid.AddWater(x, y);

            for (int k = x - 1; k <= x + 1; k++)
            {
                for (int l = y - 1; l <= y + 1; l++)
                {
                    if (liquidAmount < 256 && Main.tile[k, l].LiquidType == targettedLiquid)
                    {
                        int removeAmount = Main.tile[k, l].LiquidAmount;
                        if (removeAmount + liquidAmount > 255)
                            removeAmount = 255 - liquidAmount;

                        liquidAmount += removeAmount;
                        Main.tile[k, l].LiquidAmount -= (byte)removeAmount;
                        Tile t = Main.tile[x, y];
                        if (Main.tile[k, l].LiquidAmount == 0)
                            t.LiquidType = 0;

                        WorldGen.SquareTileFrame(k, l, resetFrame: false);
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                            NetMessage.sendWater(k, l);
                        else
                            Liquid.AddWater(k, l);
                    }
                }
            }

            return true;
        }
    }
}

using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;

namespace PboneLib.Utils
{
    public static class WorldgenUtils
    {
        public static bool BetterPlaceObject(int x, int y, int type, bool mute = false, int style = 0, int random = -1, int direction = -1)
        {
            if (!TileObject.CanPlace(x, y, type, style, direction, out TileObject objectData, false, false))
                return false;

            objectData.random = random;
            if (TileObject.Place(objectData))
            {
                WorldGen.SquareTileFrame(x, y, true);

                if (!mute)
                    SoundEngine.PlaySound(SoundID.Dig, new Vector2(x * 16, y * 16));

                return true;
            }
            return false;
        }
    }
}

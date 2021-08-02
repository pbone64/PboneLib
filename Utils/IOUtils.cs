using System;
using System.IO;
using Terraria;

namespace PboneLib.Utils
{
    public static class IOUtils
    {
        public static BitsByte PackFlags(params bool[] values)
        {
            if (values.Length > 8)
                throw new Exception("PboneLib.Core.Utils.IOUtils.PackFlags can only pack up to eight flags at a time.");

            BitsByte flags = new BitsByte(values[0], values[1], values[2], values[3], values[4], values[5], values[6], values[7]);
            return flags;
        }

        public static void WritePackedFlags(BinaryWriter writer, params bool[] values) => WritePackedFlags(writer, PackFlags(values));
        public static void WritePackedFlags(BinaryWriter writer, BitsByte values) => writer.Write(values);

        // Observe, boilerplate so future me doesn't have to
        public static void ReadPackedFlags(byte values, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6, ref bool b7, ref bool b8)
            => ReadPackedFlags((BitsByte)values, ref b1, ref b2, ref b3, ref b4, ref b5, ref b6, ref b7, ref b8);
        public static void ReadPackedFlags(BitsByte values, ref bool b1, ref bool b2, ref bool b3, ref bool b4, ref bool b5, ref bool b6, ref bool b7, ref bool b8)
        {
            b1 = values[0];
            b2 = values[1];
            b3 = values[2];
            b4 = values[3];

            b5 = values[4];
            b6 = values[5];
            b7 = values[6];
            b8 = values[7];
        }
    }
}

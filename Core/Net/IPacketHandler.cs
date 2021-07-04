using System.IO;

namespace PboneLib.Core.Net
{
    public interface IPacketHandler
    {
        void WritePacket(BinaryWriter writer);
        void ReadPacket(BinaryReader reader);
    }
}

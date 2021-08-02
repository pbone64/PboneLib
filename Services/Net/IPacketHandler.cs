using System.IO;

namespace PboneLib.Services.Net
{
    public interface IPacketHandler
    {
        void WritePacket(BinaryWriter writer);
        void ReadPacket(BinaryReader reader);
    }
}

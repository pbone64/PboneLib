using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Terraria.ModLoader;

namespace PboneLib.Core.Net
{
    public class PacketManager
    {
        public Mod Mod;

        public Dictionary<byte, IPacketHandler> PacketIdsToPacketHandlers;

        public PacketManager(Mod mod)
        {
            Mod = mod;

            PacketIdsToPacketHandlers = new Dictionary<byte, IPacketHandler>();
        }

        public void RegisterPacketHandler<T>(byte id) where T : IPacketHandler, new()
        {
            PacketIdsToPacketHandlers.Add(id, new T());
        }

        public void WritePacket<T>(BinaryWriter writer)
        {
            KeyValuePair<byte, IPacketHandler> handler = GetHandlerAndId<T>();
            WritePacket(handler.Key, writer);
        }

        public void WritePacket(byte id, BinaryWriter writer)
        {
            writer.Write(id); // Write the packets ID always
            PacketIdsToPacketHandlers[id].WritePacket(writer);
        }

        public void WriteAndSendPacket<T>()
        {
            KeyValuePair<byte, IPacketHandler> handler = GetHandlerAndId<T>();
            WriteAndSendPacket(handler.Key);
        }

        public void WriteAndSendPacket(byte id)
        {
            ModPacket packet = Mod.GetPacket();
            WritePacket(id, packet);
            packet.Send();
        }

        public void ReadPacket<T>(BinaryReader reader, bool readId = true)
        {
            KeyValuePair<byte, IPacketHandler> handler = GetHandlerAndId<T>();

            // This assumes that you haven't read anything from the reader relating to the packet at all yet
            // As such, read the id from the packet so the stream is where the handler expects 
            if (readId)
                reader.ReadByte();

            ReadPacket(handler.Key, reader);
        }

        public void ReadPacket(byte id, BinaryReader reader)
        {
            PacketIdsToPacketHandlers[id].ReadPacket(reader);
        }

        public void HandlePacket(BinaryReader reader)
        {
            byte id = reader.ReadByte();
            ReadPacket(id, reader);
        }

        public KeyValuePair<byte, IPacketHandler> GetHandlerAndId<T>() => PacketIdsToPacketHandlers.First(kvp => kvp.Value.GetType() == typeof(T));
    }
}

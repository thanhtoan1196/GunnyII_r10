using Game.Base.Packets;
using System;
namespace Game.Server.Packets.Client
{
	[PacketHandler(203, "场景用户离开")]
	public class LookupEffortHandler : IPacketHandler
	{
		public int HandlePacket(GameClient client, GSPacketIn packet)
		{
			int num = packet.ReadInt();
			Console.WriteLine("LookupEffortHandler: " + num);
			return 0;
		}
	}
}

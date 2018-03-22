using System.Numerics;
using fNbt.Tags;
using MiNET.Utils;
using MiNET.Worlds;

namespace MiNET.Items
{
	public class ItemMap : Item
	{
		public long MapId
		{
			get
			{
				if (ExtraData == null) return 0;

				return ExtraData["map_uuid"].LongValue;
			}
			set
			{
				ExtraData = new NbtCompound("tag") {new NbtLong("map_uuid", value)};
			}
		}

		public ItemMap(long mapId = 0, byte count = 1) : base(358, 0, count)
		{
			MapId = mapId;
			MaxStackSize = 1;
		}

		public override void PlaceBlock(Level world, Player player, BlockCoordinates blockCoordinates, BlockFace face, Vector3 faceCoords)
		{
		}
	}
}
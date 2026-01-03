using Kellphy.Warframe.AccountInfo.Models;

namespace Kellphy.Warframe.AccountInfo.Helpers
{
	public static class RelicHelpers
	{
		public static RelicInfo RelicInfoFromString(RelicItem relicItem)
		{
			string? name = relicItem.Relic?.name;

			var relicInfo = new RelicInfo();
			if (name is null)
			{
				return relicInfo;
			}

			string[] strings = name.Split(' ');

			if (strings.Length < 3)
			{
				return relicInfo;
			}

			relicInfo.type = strings[0];
			relicInfo.id = strings[1];
			//relicInfo.level = strings[2];
			relicInfo.count = relicItem.Item?.ItemCount ?? 0;
			return relicInfo;
		}
	}
}

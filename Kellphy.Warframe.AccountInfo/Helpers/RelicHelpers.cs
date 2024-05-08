using Kellphy.Warframe.AccountInfo.Models;
using static Kellphy.Warframe.AccountInfo.Models.RelicModel;

namespace Kellphy.Warframe.AccountInfo.Helpers
{
	public static class RelicHelpers
	{
		public static RelicInfo RelicInfoFromString(RelicItem relicItem)
		{
			string? urlName = relicItem.Relic?.marketInfo?.urlName;

			var relicInfo = new RelicInfo();
			if (urlName is null)
			{
				return relicInfo;
			}

			string[] strings = urlName.Split('_');

			if (strings.Length < 3)
			{
				return relicInfo;
			}

			relicInfo.type = strings[0];
			relicInfo.id = strings[1];
			relicInfo.count = relicItem.Item?.ItemCount ?? 0;
			return relicInfo;
		}
	}
}

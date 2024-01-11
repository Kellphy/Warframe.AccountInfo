using Kellphy.Warframe.AccountInfo.Models;

namespace Kellphy.Warframe.AccountInfo.Helpers
{
	public static class RelicHelpers
	{
		public static RelicInfo RelicInfoFromString(string? urlName)
		{
			var relicInfo = new RelicInfo();
			if (urlName == null)
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
			return relicInfo;
		}
	}
}

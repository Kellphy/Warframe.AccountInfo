using Kellphy.Warframe.AccountInfo.Models;

namespace Kellphy.Warframe.AccountInfo
{
	public static class LocalStaticData
	{
		public static List<RelicItem>? relics;

		public static void Log(string type, string text)
		{
			Console.WriteLine(text);
		}

	}
}

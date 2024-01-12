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

		public static List<string> unreleasedArcanes = new List<string>()
		{
			"Arcane",
			"Arcane Defense",
			"Arcane Detoxifier",
			"Arcane Liquid",
			"Arcane Protection",
			"Arcane Shield",
			"Arcane Survival",
			"Arcane Temperance"
		};

	}
}

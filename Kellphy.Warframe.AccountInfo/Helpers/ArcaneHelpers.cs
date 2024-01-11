using System.Text.RegularExpressions;

namespace Kellphy.Warframe.AccountInfo.Helpers
{
	public class ArcaneHelpers
	{
		private static Dictionary<string, int> _lowerLevels =
			new Dictionary<string, int>()
			{
				{"Residual", 3},
				{"Pax", 3},
				{"Exodia", 3},
				{"Virtuos", 3}
			};

		public static int ConvertFromFingerprintToLevel(string fingerprint)
		{
			if (fingerprint is null)
			{
				return 0;
			}

			string pattern = "\"lvl\":(\\d+)";

			Match match = Regex.Match(fingerprint, pattern);

			if (match.Success)
			{
				string number = match.Groups[1].Value;
				return int.Parse(number);
			}

			return -1;
		}

		public static int GetMaxLevel(string arcaneName)
		{
			//https://warframe.fandom.com/wiki/Arcane_Enhancement#Rank
			var lowerLevel = _lowerLevels.FirstOrDefault(t => arcaneName.Contains(t.Key));
			if (lowerLevel.Key is not null)
			{
				return lowerLevel.Value;
			}
			return 5;
		}
	}
}

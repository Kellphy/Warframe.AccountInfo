using Kellphy.Warframe.AccountInfo.Helpers;
using Kellphy.Warframe.AccountInfo.Imported.Models;
using Kellphy.Warframe.AccountInfo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;

namespace Kellphy.Warframe.AccountInfo
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			while(true)
			{
				MainMenu();
				Console.WriteLine("\nPress any key to restart ...");
				Console.ReadKey();
				Console.Clear();
			}
		}

		private static void MainMenu()
		{
			Console.WriteLine(
				"[1] Relics\n" +
				"[2] Arcanes");
			Console.Write("Choice: ");
			var choice = Console.ReadKey();
			Console.WriteLine();

			var jsonData = ImportFromDataFile();
			switch (choice.Key)
			{
				case ConsoleKey.D1:
					var miscItems = jsonData.Deserialize<Miscitem>("MiscItems");
					if (miscItems is null)
					{
						return;
					}
					GetRelics(miscItems);
					RelicLogic();
					break;

				case ConsoleKey.D2:
					var arcaneGroups = GetArcanes(jsonData);
					if (arcaneGroups is null)
					{
						return;
					}

					var arcanesToSell = new List<ArcaneItem>();
					var arcanesToComplete = new List<ArcaneItem>();

					foreach (var arcaneType in arcaneGroups)
					{
						var maxLevel = ArcaneHelpers.GetMaxLevel(arcaneType.Key);
						if (arcaneType.Any(t => t.Level == maxLevel) && arcaneType.Count() > 1)
						{
							arcanesToSell.AddRange(arcaneType.Where(t => t.Level < maxLevel));
						}
						else if (!arcaneType.Any(t => t.Level == maxLevel))
						{
							arcanesToComplete.AddRange(arcaneType);
						}
					}

					Console.ForegroundColor = ConsoleColor.Red;
					Console.WriteLine("\n##### Arcanes to Complete #####\n");
					Console.WriteLine(string.Join("\n",
						arcanesToComplete.Select(t => $"{t.Name} {t.Level} ({t.Count})")
						.OrderBy(t => t)));

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\n##### Arcanes to Sell #####\n");
					Console.WriteLine(string.Join("\n",
						arcanesToSell.Select(t => $"{t.Name} {t.Level} ({t.Count})")
						.OrderBy(t => t)));

					Console.ForegroundColor = ConsoleColor.Gray;
					break;
				default:
					return;
			}
		}


		#region Common
		private static JObject ImportFromDataFile()
		{
			var result = ReadAllTextEncrypted(StaticData.saveFolder + "\\lastData.dat");
			File.WriteAllText(StaticData.saveFolder + "\\lastData.json", result);
			return JObject.Parse(result);
		}
		public static string ReadAllTextEncrypted(string path)
		{
			string text = File.ReadAllText(path);
			if (text.First() == '{' && text.Last() == '}')
			{
				return text;
			}
			using (AesManaged aesManaged = new AesManaged())
			{
				ICryptoTransform transform = aesManaged.CreateDecryptor(StaticData.lastDataKey, StaticData.lastDataIV);
				using (MemoryStream stream = new MemoryStream(File.ReadAllBytes(path)))
				{
					using (CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read))
					{
						using (StreamReader streamReader = new StreamReader(stream2))
						{
							return streamReader.ReadToEnd();
						}
					}
				}
			}
		}
		#endregion

		#region Relics
		private static void GetRelics(List<Miscitem> miscItems)
		{
			var jsonContents = File.ReadAllText(StaticData.saveFolder + "/cachedData/json/Relics.json");

			// Call the method to deserialize the JSON data and map it to the Root model
			var relics = JsonConvert.DeserializeObject<RelicModel.Root[]>(jsonContents);
			if (relics == null)
			{
				return;
			}
			var ownedRelics = new List<RelicItem>();
			Console.WriteLine("Vaulted Only? (Y/N)");
			var vaultedOnly = false;
			if (Console.ReadKey().Key == ConsoleKey.Y)
			{
				vaultedOnly = true;
			}
			Console.WriteLine("\nMinimum count?");
			var minCount = 1;
			var parsed = Int32.TryParse(Console.ReadLine(), out int result);
			if (parsed)
			{
				minCount = result;
			}
			Console.WriteLine($"\nYour relics with at least {minCount} of each:\n");
			foreach (var relic in relics)
			{
				var miscItem = miscItems.FirstOrDefault(t => t.ItemType == relic.uniqueName);
				if (miscItem != null)
				{
					if (!vaultedOnly || relic.vaulted)
					{
						if (miscItem.ItemCount >= minCount)
						{
							ownedRelics.Add(new RelicItem()
							{
								Item = miscItem,
								Relic = relic
							});
						}
					}
				}
			}
			LocalStaticData.relics = ownedRelics;
			var relicGroups = ownedRelics?.GroupBy(t => RelicHelpers.RelicInfoFromString(t.Relic?.marketInfo?.urlName).type);
			if (relicGroups == null)
			{
				return;
			}
			var output = $"+";
			foreach (var relicGroup in relicGroups)
			{
				if (relicGroup != null && relicGroup.Key?.ToLower() != "requiem")
				{
					output += $" {relicGroup.Key} ";

					output += string.Join(" ", relicGroup.Select(t => RelicHelpers.RelicInfoFromString(t.Relic?.marketInfo?.urlName).id).Distinct()); ;
				}
			}

			Console.WriteLine(output);
		}
		private static void RelicLogic()
		{
			var relicData = LocalStaticData.relics?.Select(t => RelicHelpers.RelicInfoFromString(t.Relic?.marketInfo?.urlName));
			while (true)
			{
				Console.WriteLine("\nPaste text to check relics from:\n");
				string? input = string.Empty;
				var lines = new List<string>();

				while ((input = Console.ReadLine()) != "exit")
				{
					if (input != null)
					{
						lines.Add(input);
					}
				}

				Console.WriteLine("\nGroups that you can apply for:\n");

				foreach (var line in lines)
				{
					var formattedLine = line.Replace("@", "");
					string[] words = formattedLine.Split(' ');

					for (int i = 0; i < words.Length - 1; i++)
					{
						var relic = relicData.FirstOrDefault(t =>
						t.type?.ToLower() == words[i].ToLower()
						&& t.id?.ToLower() == words[i + 1].ToLower());
						if (relic != null)
						{
							Console.WriteLine($"{line}\n----- with your: {relic.type} {relic.id}");
						}
					}
				}
			}
		}
		#endregion

		#region Arcanes
		public static List<Miscitem> GetInventoryArcanes(List<Miscitem> rawUpgrades, List<Upgrade> upgrades)
		{
			var list = rawUpgrades.Where(p => p.IsArcane()).ToList();
			list.AddRange(upgrades.Where(p => p.IsArcane()).GroupBy(p => p.UpgradeFingerprint + p.ItemType).Select(p => new Miscitem()
			{
				ItemType = p.First().ItemType,
				ItemCount = p.Count(),
				UpgradeFingerprint = p.First().UpgradeFingerprint
			}));
			return list;
		}
		private static List<IGrouping<string, ArcaneItem>>? GetArcanes(JObject jsonData)
		{
			var allArcanesString = File.ReadAllText(StaticData.saveFolder + "/cachedData/json/Arcanes.json");
			var allArcanesList = JsonConvert.DeserializeObject<List<DataArcane>>(allArcanesString)?.ToDictionary(dataPoint => dataPoint.uniqueName);
			if (allArcanesList is null)
			{
				return null;
			}
			var rawUpgrades = jsonData.Deserialize<Miscitem>("RawUpgrades");
			var upgrades = jsonData.Deserialize<Upgrade>("Upgrades");

			var inventoryArcanes = GetInventoryArcanes(rawUpgrades, upgrades);

			var arcaneList = inventoryArcanes.Select(t =>
			new ArcaneItem()
			{
				Name = allArcanesList.GetValueOrDefault(t.ItemType)?.name ?? t.ItemType,
				Count = t.ItemCount,
				Level = ArcaneHelpers.ConvertFromFingerprintToLevel(t.UpgradeFingerprint)
			}).GroupBy(t => t.Name).ToList();
			return arcaneList;
		}
		#endregion

	}
}
using AlecaFrameClientLib;
using AlecaFrameClientLib.Data.Types;
using AlecaFrameClientLib.Utils;
using Kellphy.Warframe.AccountInfo.Helpers;
using Kellphy.Warframe.AccountInfo.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Security.Cryptography;

namespace Kellphy.Warframe.AccountInfo
{
	internal class Program
	{
		private static readonly List<string> _namePrefixesToRemove = new()
		{
			"/Lotus/Upgrades/CosmeticEnhancers/Antiques/"
		};

		private static string CleanName(string name)
		{
			foreach (var prefix in _namePrefixesToRemove)
			{
				name = name.Replace(prefix, "/ ");
			}
			return name;
		}

		private static void Main(string[] args)
		{
			Console.ForegroundColor = ConsoleColor.Gray;
			while (true)
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

			var jsonRootData = ImportFromDataFile();
			var root = jsonRootData.ToObject<WarframeRootObject>();
			switch (choice.Key)
			{
				case ConsoleKey.D1:
					var miscItems = root!.MiscItems.ToList();
					if (miscItems is null)
					{
						return;
					}
					Console.WriteLine($"Found {miscItems.Count} items");

					GetRelics(miscItems);
					RelicLogic();
					break;

				case ConsoleKey.D2:
					var allArcanes = GetArcanes();
					if (allArcanes is null)
					{
						return;
					}
					Console.WriteLine($"Found {allArcanes.Count} arcanes");

					var arcaneGroups = GetInventoryArcanes(root!.RawUpgrades, root!.Upgrades, allArcanes);
					if (arcaneGroups is null)
					{
						return;
					}
					Console.WriteLine($"Found {arcaneGroups.Count} inventory arcanes");

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
					Console.WriteLine("\n##### Arcanes not Owned #####\n");
					var notOwned = allArcanes.Where(t => !arcaneGroups.Any(s => s.Key == t.Value.name) &&
						!LocalStaticData.unreleasedArcanes.Any(s => s == t.Value.name))
						.Select(t => t.Value.name)
						.OrderBy(t => t).ToList();
					List<string> stringList = notOwned.Select(t => GetWarframeMarketURLName(t)).ToList();
					string dataToSend = JsonConvert.SerializeObject((object)stringList);
					ItemPriceSmallResponse[]? priceSmallResponseArray = JsonConvert.DeserializeObject<ItemPriceSmallResponse[]>(MakePOSTRequest(StaticData.PricesAPIHostname + "/priceData", dataToSend, (int)TimeSpan.FromSeconds(7.0).TotalMilliseconds, 1));
					if (priceSmallResponseArray is not null && priceSmallResponseArray.Length == stringList.Count)
					{
						for (int i = 0; i < priceSmallResponseArray.Length; i++)
						{
							var ItemPriceSmallResponse = priceSmallResponseArray[i];
							Console.WriteLine($"{notOwned[i]}" +
								$" | MinBuy({ItemPriceSmallResponse.insta})" +
								$" MinSell({ItemPriceSmallResponse.post}) PostMax({ItemPriceSmallResponse.postMax})" +
								$" MinR0({ItemPriceSmallResponse.minR0}) MinRMax({ItemPriceSmallResponse.minRMax})" +
								$" Volume({ItemPriceSmallResponse.volume})");
						}
					}

					Console.ForegroundColor = ConsoleColor.DarkYellow;
					Console.WriteLine("\n##### Arcanes to Complete #####\n");
					Console.WriteLine(string.Join("\n",
						arcanesToComplete.Select(t => $"{CleanName(t.Name)} {t.Level} ({t.Count})" +
						$" | MinBuy({t.ItemPriceSmallResponse?.insta})" +
						$" MinSell({t.ItemPriceSmallResponse?.post}) PostMax({t.ItemPriceSmallResponse?.postMax})" +
						$" MinR0({t.ItemPriceSmallResponse?.minR0}) MinRMax({t.ItemPriceSmallResponse?.minRMax})" +
						$" Volume({t.ItemPriceSmallResponse?.volume})")
						.OrderBy(t => t)));

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("\n##### Arcanes to Sell #####\n");
					Console.WriteLine(string.Join("\n",
						arcanesToSell.Select(t => $"{CleanName(t.Name)} {t.Level} ({t.Count})" +
						$" | MinBuy({t.ItemPriceSmallResponse?.insta})" +
						$" MinSell({t.ItemPriceSmallResponse?.post}) PostMax({t.ItemPriceSmallResponse?.postMax})" +
						$" MinR0({t.ItemPriceSmallResponse?.minR0}) MinRMax({t.ItemPriceSmallResponse?.minRMax})" +
						$" Volume({t.ItemPriceSmallResponse?.volume})")
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
			var lastDataPath = StaticData.saveFolder + "\\lastData.dat";
			var result = ReadAllTextEncrypted(lastDataPath);

			Console.WriteLine($"Last Updated: {new FileInfo(lastDataPath).LastWriteTime} with {result.Length} characters");

			return JObject.Parse(result);
		}
		public static string ReadAllTextEncrypted(string path)
		{
			string text = File.ReadAllText(path);
			if (text.First() == '{' && text.Last() == '}')
			{
				return text;
			}
			using (var aesManaged = new AesManaged())
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
			var relicGroups = ownedRelics?.GroupBy(t => RelicHelpers.RelicInfoFromString(t).type);
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

					output += string.Join(" ", relicGroup.Select(t => RelicHelpers.RelicInfoFromString(t).id).Distinct());
				}
			}

			Console.WriteLine(output);
		}
		private static void RelicLogic()
		{
			var relicData = LocalStaticData.relics?.Select(t => RelicHelpers.RelicInfoFromString(t));
			while (true)
			{
				var stringToExit = "q";
				Console.WriteLine($"\nPaste text to check relics from ({stringToExit} to exit):\n");
				Console.ForegroundColor = ConsoleColor.DarkGray;
				string? input = string.Empty;
				var lines = new List<string>();

				while ((input = Console.ReadLine()) != stringToExit)
				{
					if (input != null)
					{
						lines.Add(input);
					}
				}
				Console.ForegroundColor = ConsoleColor.Gray;

				Console.WriteLine("\nGroups that you can apply for:\n");

				foreach (var line in lines)
				{
					var formattedLine = line.Replace("@", "");
					string[] words = formattedLine.Split(' ');

					var relics = new List<RelicInfo>();
					for (int i = 0; i < words.Length - 1; i++)
					{
						var relic = relicData?.FirstOrDefault(t =>
						t.type?.ToLower() == words[i].ToLower()
						&& t.id?.ToLower() == words[i + 1].ToLower());
						if (relic != null)
						{
							relics.Add(relic);
						}
					}

					if (relics.Count > 0)
					{
						Console.ForegroundColor = ConsoleColor.Yellow;
						Console.WriteLine(line);
						Console.ForegroundColor = ConsoleColor.Green;
						relics.ForEach(t => Console.WriteLine($"+ {t.type} {t.id} ({t.count})"));
						Console.ForegroundColor = ConsoleColor.Gray;
					}
				}
			}
		}
		#endregion

		#region Arcanes
		private static Dictionary<string, DataArcane>? GetArcanes()
		{
			var allArcanesString = File.ReadAllText(StaticData.saveFolder + "/cachedData/json/Arcanes.json");
			var allArcanesList = JsonConvert.DeserializeObject<List<DataArcane>>(allArcanesString)?.ToDictionary(dataPoint => dataPoint.uniqueName);
			return allArcanesList;
		}

		public static string GetWarframeMarketURLName(string humanName)
		{
			if (humanName == null)
				return "";
			humanName = humanName.ToLower();
			if (humanName == null)
				humanName = "";
			if (humanName.Contains("radiant") || humanName.Contains("intact") || humanName.Contains("exceptional") || humanName.Contains("flawless"))
			{
				humanName = humanName.Replace(" radiant", "").Replace(" intact", "").Replace(" exceptional", "").Replace(" flawless", "");
				humanName += " relic";
			}
			humanName = humanName.Trim().Replace("&", "and").Replace("'", "").Replace("-", "_").Replace(" ", "_");
			humanName = humanName.Replace("prisma_dual_decurions", "prisma_dual_decurion");
			if (humanName == "dark_split_sword")
				humanName = "dark_split_sword_(dual_swords)";
			return humanName;
		}

		private static List<IGrouping<string, ArcaneItem>> GetInventoryArcanes(Miscitem[] rawUpgrades, Miscitem[] upgrades, Dictionary<string, DataArcane> allArcanesList)
		{
			var inventoryArcanes = rawUpgrades.Where(p => p.IsArcane()).ToList();
			inventoryArcanes.AddRange(upgrades.Where(p => p.IsArcane()).GroupBy(p => p.UpgradeFingerprint + p.ItemType).Select(p => new Miscitem()
			{
				ItemType = p.First().ItemType,
				ItemCount = p.Count(),
				UpgradeFingerprint = p.First().UpgradeFingerprint
			}));

			var arcaneList = inventoryArcanes.Select(t =>
			new ArcaneItem()
			{
				Name = allArcanesList.GetValueOrDefault(t.ItemType)?.name ?? t.ItemType,
				Count = t.ItemCount,
				Level = ArcaneHelpers.ConvertFromFingerprintToLevel(t.UpgradeFingerprint)
			}).GroupBy(t => t.Name).ToList();

			List<string> stringList = arcaneList.Select(t => GetWarframeMarketURLName(t.Key)).ToList();
			string dataToSend = JsonConvert.SerializeObject((object)stringList);
			ItemPriceSmallResponse[]? priceSmallResponseArray = JsonConvert.DeserializeObject<ItemPriceSmallResponse[]>(MakePOSTRequest(StaticData.PricesAPIHostname + "/priceData", dataToSend, (int)TimeSpan.FromSeconds(7.0).TotalMilliseconds, 1));

			if(priceSmallResponseArray is not null && priceSmallResponseArray.Length == stringList.Count)
			{
				for (int i = 0; i < priceSmallResponseArray.Length; i++)
				{
					foreach(var arcaneEntry in arcaneList[i])
					{
						arcaneEntry.ItemPriceSmallResponse = priceSmallResponseArray[i];
					}
				}
			}

			//GetBuySellWindowData(arcaneList.First().First().Name, HandleMarketData);

			return arcaneList;
		}

		//static void HandleMarketData(object success, object buySellData, object subtypes)
		//{
		//	if ((bool)success)
		//	{
		//		Console.WriteLine("Data retrieved successfully!");
		//		Console.WriteLine("Buy/Sell Data: " + buySellData);
		//		Console.WriteLine("Subtypes: " + subtypes);
		//	}
		//	else
		//	{
		//		Console.WriteLine("Failed to retrieve market data.");
		//	}
		//}

		//public static void GetBuySellWindowData(string itemName, Action<object, object, object> callback) => Task.Run((Action)(() =>
		//{
		//	try
		//	{
		//		MyWebClient myWebClient = new MyWebClient();
		//		myWebClient.Proxy = (IWebProxy)null;
		//		myWebClient.Headers.Add(System.Net.HttpRequestHeader.Accept, "application/json");
		//		string warframeMarketUrlName = GetWarframeMarketURLName(itemName);
		//		WFMarketOrdersResponse allOrders = JsonConvert.DeserializeObject<WFMarketOrdersResponse>(myWebClient.DownloadString("https://api.warframe.market/v1//items/" + warframeMarketUrlName + "/orders?include=item"));
		//		IEnumerable<Order> source1 = ((IEnumerable<Order>)allOrders.payload.orders).Where<Order>((Func<Order, bool>)(p => p.user.status == "ingame"));
		//		IOrderedEnumerable<Order> source2 = source1.Where<Order>((Func<Order, bool>)(p => p.order_type == "sell" && p.region == "en")).OrderBy<Order, int>((Func<Order, int>)(p => p.platinum));
		//		IOrderedEnumerable<Order> source3 = source1.Where<Order>((Func<Order, bool>)(p => p.order_type == "buy" && p.region == "en")).OrderByDescending<Order, int>((Func<Order, int>)(p => p.platinum));
		//		WFItemInclude include = allOrders.include;
		//		ItemsInSet itemsInSet1;
		//		if (include == null)
		//		{
		//			itemsInSet1 = (ItemsInSet)null;
		//		}
		//		else
		//		{
		//			WFItemPayload wfItemPayload = include.item;
		//			if (wfItemPayload == null)
		//			{
		//				itemsInSet1 = (ItemsInSet)null;
		//			}
		//			else
		//			{
		//				ItemsInSet[] itemsInSet2 = wfItemPayload.items_in_set;
		//				itemsInSet1 = itemsInSet2 != null ? ((IEnumerable<ItemsInSet>)itemsInSet2).FirstOrDefault<ItemsInSet>((Func<ItemsInSet, bool>)(p => p.id == allOrders.include?.item?.id)) : (ItemsInSet)null;
		//			}
		//		}
		//		ItemsInSet itemsInSet3 = itemsInSet1;
		//		BuySellPanelResponse sellPanelResponse = new BuySellPanelResponse();
		//		sellPanelResponse.buyListings = source3.Select<Order, BuySellPanelResponseItem>((Func<Order, BuySellPanelResponseItem>)(p => new BuySellPanelResponseItem(p))).ToList<BuySellPanelResponseItem>();
		//		sellPanelResponse.sellListings = source2.Select<Order, BuySellPanelResponseItem>((Func<Order, BuySellPanelResponseItem>)(p => new BuySellPanelResponseItem(p))).ToList<BuySellPanelResponseItem>();
		//		if (GetWarframeMarketURLName(itemName).ToLower().Contains("relic"))
		//		{
		//			sellPanelResponse.postingSettings.isRelic = true;
		//			sellPanelResponse.buyListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.ToUpper().ToCharArray()[0].ToString()));
		//			sellPanelResponse.sellListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.ToUpper().ToCharArray()[0].ToString()));
		//		}
		//		else if (((IEnumerable<Order>)allOrders.payload.orders).Any<Order>((Func<Order, bool>)(p => p.mod_rank != -69)))
		//		{
		//			sellPanelResponse.postingSettings.isMod = true;
		//			sellPanelResponse.buyListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.mod_rank.ToString()));
		//			sellPanelResponse.sellListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.mod_rank.ToString()));
		//		}
		//		else
		//		{
		//			ItemsInSet[] itemsInSet4 = allOrders.include.item.items_in_set;
		//			if ((itemsInSet4 != null ? (((IEnumerable<ItemsInSet>)itemsInSet4).Any<ItemsInSet>((Func<ItemsInSet, bool>)(p =>
		//			{
		//				List<string> tags = p.tags;
		//				// ISSUE: explicit non-virtual call
		//				return tags != null && tags.Contains("fish");
		//			})) ? 1 : 0) : 0) != 0)
		//			{
		//				ItemsInSet[] itemsInSet5 = allOrders.include.item.items_in_set;
		//				if ((itemsInSet5 != null ? (((IEnumerable<ItemsInSet>)itemsInSet5).Any<ItemsInSet>((Func<ItemsInSet, bool>)(p =>
		//				{
		//					List<string> subtypes = p.subtypes;
		//					// ISSUE: explicit non-virtual call
		//					return subtypes != null && subtypes.Contains("small");
		//				})) ? 1 : 0) : 0) != 0)
		//					sellPanelResponse.postingSettings.isFish = true;
		//				else
		//					sellPanelResponse.postingSettings.isFish2 = true;
		//				sellPanelResponse.buyListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.FirstCharToUpper()));
		//				sellPanelResponse.sellListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.FirstCharToUpper()));
		//			}
		//			else if (itemName.Contains("(veiled)"))
		//			{
		//				sellPanelResponse.postingSettings.isVeiledRiven = true;
		//				sellPanelResponse.buyListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.FirstCharToUpper()));
		//				sellPanelResponse.sellListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = p.order.subtype.FirstCharToUpper()));
		//			}
		//			else
		//			{
		//				ItemsInSet[] itemsInSet6 = allOrders.include.item.items_in_set;
		//				if ((itemsInSet6 != null ? (((IEnumerable<ItemsInSet>)itemsInSet6).Any<ItemsInSet>((Func<ItemsInSet, bool>)(p =>
		//				{
		//					List<string> tags = p.tags;
		//					// ISSUE: explicit non-virtual call
		//					return tags != null && tags.Contains("ayatan_sculpture");
		//				})) ? 1 : 0) : 0) != 0)
		//				{
		//					sellPanelResponse.postingSettings.isAyatan = true;
		//					sellPanelResponse.buyListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = string.Format("{0} cyan, {1} amber", (object)p.order.cyan_stars, (object)p.order.amber_stars)));
		//					sellPanelResponse.sellListings.ForEach((Action<BuySellPanelResponseItem>)(p => p.specialValue = string.Format("{0} cyan, {1} amber", (object)p.order.cyan_stars, (object)p.order.amber_stars)));
		//				}
		//			}
		//		}
		//		sellPanelResponse.postingSettings.wfmItemName = allOrders.include.item.id;
		//		sellPanelResponse.postingSettings.readableName = itemName;
		//		callback((object)true, (object)JsonConvert.SerializeObject((object)sellPanelResponse), (object)JsonConvert.SerializeObject((object)itemsInSet3?.subtypes));
		//	}
		//	catch (Exception ex)
		//	{
		//		StaticData.Log(OverwolfWrapper.LogType.ERROR, "An error has ocurred when getting huge price list: " + ex.Message);
		//		callback((object)false, (object)"", (object)"");
		//	}
		//}));

		public static string MakePOSTRequest(
			string url,
			string dataToSend,
			int timeoutMSperRequest = 100000,
			int retries = 3)
		{
			MyWebClient myWebClient = new MyWebClient(timeoutMSperRequest);
			myWebClient.Proxy = (IWebProxy)null;
			string str = "";
			int num = retries;
			do
			{
				try
				{
					myWebClient.Headers.Add(HttpRequestHeader.ContentType, "application/json");
					str = myWebClient.UploadString(url, dataToSend);
					break;
				}
				catch
				{
					--num;
					StaticData.Log(OverwolfWrapper.LogType.WARN, "Failed to make POST request: " + url);
					if (num <= 0)
						throw;
				}
			}
			while (num > 0);
			return str;
		}
		#endregion

	}
}
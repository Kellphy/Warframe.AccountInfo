// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.DataMod
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class DataMod : BigItem
	{
		public int baseDrain { get; set; }

		public string compatName { get; set; }

		public int fusionLimit { get; set; }

		//public Introduced introduced { get; set; }

		public bool isAugment { get; set; }

		//public Levelstat[] levelStats { get; set; }

		public string polarity { get; set; }

		public string rarity { get; set; }

		public bool tradable { get; set; }

		public bool transmutable { get; set; }

		public string wikiaThumbnail { get; set; }

		public bool isUtility { get; set; }

		public string modSet { get; set; }

		public bool isExilus { get; set; }

		public bool excludeFromCodex { get; set; }

		//public Availablechallenge[] availableChallenges { get; set; }

		//public Upgradeentry[] upgradeEntries { get; set; }

		public float[] modSetValues { get; set; }

		public override bool IsFullyMastered() => false;

		public override int GetAccountMasteryGivenPerLevel() => 0;

		public override int GetMasteryLevel(long XP) => 0;

		public override int GetMaxMasteryLevel() => 0;

		public override bool IsOwned()
		{
			//  DataHandler dataHandler1 = StaticData.dataHandler;
			//  bool? nullable1;
			//  if (dataHandler1 == null)
			//  {
			//    nullable1 = new bool?();
			//  }
			//  else
			//  {
			//    WarframeRootObject warframeRootObject = dataHandler1.warframeRootObject;
			//    if (warframeRootObject == null)
			//    {
			//      nullable1 = new bool?();
			//    }
			//    else
			//    {
			//      Upgrade[] upgrades = warframeRootObject.Upgrades;
			//      nullable1 = upgrades != null ? new bool?(((IEnumerable<Upgrade>) upgrades).Any<Upgrade>((Func<Upgrade, bool>) (p => p.ItemType == this.uniqueName))) : new bool?();
			//    }
			//  }
			//  if (nullable1.GetValueOrDefault())
			//    return true;
			//  DataHandler dataHandler2 = StaticData.dataHandler;
			//  bool? nullable2;
			//  if (dataHandler2 == null)
			//  {
			//    nullable2 = new bool?();
			//  }
			//  else
			//  {
			//    WarframeRootObject warframeRootObject = dataHandler2.warframeRootObject;
			//    if (warframeRootObject == null)
			//    {
			//      nullable2 = new bool?();
			//    }
			//    else
			//    {
			//      Miscitem[] rawUpgrades = warframeRootObject.RawUpgrades;
			//      nullable2 = rawUpgrades != null ? new bool?(((IEnumerable<Miscitem>) rawUpgrades).Any<Miscitem>((Func<Miscitem, bool>) (p => p.ItemType == this.uniqueName))) : new bool?();
			//    }
			//  }
			//  return nullable2.GetValueOrDefault();
			throw new NotImplementedException();
		}

		public static double GetModTypeEndoMultipler(string modType)
		{
			switch (modType)
			{
				case "bronze":
					return 1.0;
				case "silver":
					return 2.0;
				case "gold":
				case "riven":
					return 3.0;
				case "primed":
					return 4.0;
				default:
					return 0.0;
			}
		}

		//public int GetMaxModLevel()
		//{
		//  if (this.uniqueName.StartsWith("/Lotus/Upgrades/Mods/Railjack/"))
		//    return this.fusionLimit;
		//  int fusionLimit = this.fusionLimit;
		//  Levelstat[] levelStats = this.levelStats;
		//  int val2 = (levelStats != null ? levelStats.Length : 1) - 1;
		//  return Math.Max(fusionLimit, val2);
		//}
	}
}

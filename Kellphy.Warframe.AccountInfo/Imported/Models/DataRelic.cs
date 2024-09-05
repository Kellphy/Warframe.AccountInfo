// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.DataRelic
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A886CA06-AEA1-4DF9-9273-8423A987943C
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.62\NET\AlecaFrameClientLib.dll

namespace AlecaFrameClientLib.Data.Types
{
	public class DataRelic : BigItem
	{
		public Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData> relicRewards = new Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData>();

		public bool tradable { get; set; }

		public override bool IsFullyMastered() => false;

		public override int GetMasteryLevel(long XP) => 0;

		public override int GetMaxMasteryLevel() => 0;

		public override int GetAccountMasteryGivenPerLevel() => 0;

		public override bool IsOwned() => StaticData.dataHandler.warframeRootObject != null && ((IEnumerable<Miscitem>)StaticData.dataHandler.warframeRootObject.MiscItems).Any<Miscitem>((Func<Miscitem, bool>)(p => p.ItemType == this.uniqueName));

		public class RelicDropData
		{
			public List<DataRelic.RelicDropData.RelicDropDataWithRarity> chance = new List<DataRelic.RelicDropData.RelicDropDataWithRarity>();

			public class RelicDropDataWithRarity
			{
				public float chance;
				public DataRelic.RelicDropData.ItemRarity rarity;
				public ItemComponent item;
			}

			public enum ItemRarity
			{
				Common,
				Uncommon,
				Rare,
			}
		}

		public enum RelicRarities
		{
			Intact,
			Exceptional,
			Flawless,
			Radiant,
		}
	}
}

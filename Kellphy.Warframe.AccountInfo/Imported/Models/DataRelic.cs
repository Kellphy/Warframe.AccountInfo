// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.DataRelic
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlecaFrameClientLib.Data.Types
{
	public class DataRelic : BigItem
	{
		public Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData> relicRewards = new Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData>();
		public List<DataRelic.DataRelicReward> rewards = new List<DataRelic.DataRelicReward>();

		public bool tradable { get; set; }

		public override bool IsFullyMastered() => false;

		public override int GetMasteryLevel(long XP) => 0;

		public override int GetMaxMasteryLevel() => 0;

		public override int GetAccountMasteryGivenPerLevel() => 0;

		public override bool IsOwned() => StaticData.dataHandler.warframeRootObject != null && ((IEnumerable<Miscitem>)StaticData.dataHandler.warframeRootObject.MiscItems).Any<Miscitem>((Func<Miscitem, bool>)(p => p.ItemType == this.uniqueName));

		public class DataRelicReward
		{
			public string rarity;
			public float chance;
			public DataRelic.DataRelicReward.DataRelicRewardItem item;

			public class DataRelicRewardItem
			{
				public string name;
			}
		}

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

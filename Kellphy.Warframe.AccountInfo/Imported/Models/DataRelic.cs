// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.DataRelic
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class DataRelic : BigItem
	{
		public Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData> relicRewards = new Dictionary<DataRelic.RelicRarities, DataRelic.RelicDropData>();

		public bool tradable { get; set; }

		public override bool IsFullyMastered() => false;

		public override int GetMasteryLevel(long XP) => 0;

		public override int GetMaxMasteryLevel() => 0;

		public override int GetAccountMasteryGivenPerLevel() => 0;

		public override bool IsOwned()
		{
			throw new NotImplementedException();
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

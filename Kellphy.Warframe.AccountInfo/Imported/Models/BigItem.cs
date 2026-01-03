// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.BigItem
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlecaFrameClientLib.Data.Types
{
	public abstract class BigItem
	{
		public List<BigItem> isPartOf = new List<BigItem>();
		public float? marketCost = new float?(0.0f);

		public string name { get; set; }

		public ItemComponent[] components { get; set; }

		public string imageName { get; set; }

		public int masteryReq { get; set; }

		public string uniqueName { get; set; }

		public string category { get; set; }

		public string wikiaUrl { get; set; }

		public string releaseDate { get; set; }

		public double omegaAttenuation { get; set; }

		public double disposition { get; set; }

		public string description { get; set; }

		public string estimatedVaultDate { get; set; }

		public bool vaulted { get; set; }

		public string vaultDate { get; set; }

		public string productCategory { get; set; }

		public string type { get; set; }

		public Drop[] drops { get; set; }

		public abstract bool IsFullyMastered();

		public abstract int GetMasteryLevel(long XP);

		public abstract int GetMaxMasteryLevel();

		public abstract int GetAccountMasteryGivenPerLevel();

		protected bool isFullyMasteredInner(int expNeeded)
		{
			try
			{
				if (StaticData.dataHandler.warframeRootObject == null)
					return false;
				Xpinfo xpinfo = ((IEnumerable<Xpinfo>)StaticData.dataHandler.warframeRootObject.XPInfo).FirstOrDefault<Xpinfo>((Func<Xpinfo, bool>)(p => p.ItemType == this.uniqueName));
				if (xpinfo != null)
					return xpinfo.XP >= expNeeded;
				WarframeRootObject warframeRootObject1 = StaticData.dataHandler.warframeRootObject;
				List<Moapet> moapetList;
				if (warframeRootObject1 == null)
				{
					moapetList = (List<Moapet>)null;
				}
				else
				{
					Moapet[] moaPets = warframeRootObject1.MoaPets;
					moapetList = moaPets != null ? ((IEnumerable<Moapet>)moaPets).Where<Moapet>((Func<Moapet, bool>)(p => ((IEnumerable<string>)p.ModularParts).Contains<string>(this.uniqueName))).ToList<Moapet>() : (List<Moapet>)null;
				}
				List<Moapet> source1 = moapetList;
				if (source1.Any<Moapet>())
					return source1.Max<Moapet>((Func<Moapet, int>)(p => p.XP)) >= expNeeded;
				WarframeRootObject warframeRootObject2 = StaticData.dataHandler.warframeRootObject;
				IEnumerable<Kubrowpet> kubrowpets;
				if (warframeRootObject2 == null)
				{
					kubrowpets = (IEnumerable<Kubrowpet>)null;
				}
				else
				{
					Kubrowpet[] kubrowPets = warframeRootObject2.KubrowPets;
					kubrowpets = kubrowPets != null ? ((IEnumerable<Kubrowpet>)kubrowPets).Where<Kubrowpet>((Func<Kubrowpet, bool>)(p => p.ItemType == this.uniqueName)) : (IEnumerable<Kubrowpet>)null;
				}
				IEnumerable<Kubrowpet> source2 = kubrowpets;
				return source2.Any<Kubrowpet>() && source2.Max<Kubrowpet>((Func<Kubrowpet, int>)(p => p.XP)) >= expNeeded;
			}
			catch
			{
				return false;
			}
		}

		public long GetXP()
		{
			DataHandler dataHandler = StaticData.dataHandler;
			int? nullable;
			if (dataHandler == null)
			{
				nullable = new int?();
			}
			else
			{
				WarframeRootObject warframeRootObject = dataHandler.warframeRootObject;
				if (warframeRootObject == null)
				{
					nullable = new int?();
				}
				else
				{
					Xpinfo[] xpInfo = warframeRootObject.XPInfo;
					nullable = xpInfo != null ? ((IEnumerable<Xpinfo>)xpInfo).FirstOrDefault<Xpinfo>((Func<Xpinfo, bool>)(p => p.ItemType == this.uniqueName))?.XP : new int?();
				}
			}
			return (long)nullable.GetValueOrDefault();
		}

		public bool IsPrime() => this.name.ToLower().Contains("prime");

		public abstract bool IsOwned();
	}
}

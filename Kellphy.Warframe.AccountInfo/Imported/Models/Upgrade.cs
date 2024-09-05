// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Upgrade
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A886CA06-AEA1-4DF9-9273-8423A987943C
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.62\NET\AlecaFrameClientLib.dll

namespace AlecaFrameClientLib.Data.Types
{
	public class Upgrade : Miscitem
	{
		public int TryGetModRank(int defaultModRank = 0)
		{
			try
			{
				if (string.IsNullOrEmpty(this.UpgradeFingerprint))
					return defaultModRank;
				ExtraModData extraModData = ExtraModData.DeserializeFromString(this.UpgradeFingerprint);
				return extraModData == null ? defaultModRank : extraModData.lvl;
			}
			catch
			{
				return defaultModRank;
			}
		}
	}
}

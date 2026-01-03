// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Upgrade
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

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

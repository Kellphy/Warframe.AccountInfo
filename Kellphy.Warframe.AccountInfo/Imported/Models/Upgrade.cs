// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.Upgrade
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class Upgrade : Miscitem
	{
		public int TryGetModRank(int defaultModRank = 0)
		{
			try
			{
				if (string.IsNullOrEmpty(UpgradeFingerprint))
					return defaultModRank;
				ExtraModData extraModData = ExtraModData.DeserializeFromString(UpgradeFingerprint);
				return extraModData == null ? defaultModRank : extraModData.lvl;
			}
			catch
			{
				return defaultModRank;
			}
		}
	}
}

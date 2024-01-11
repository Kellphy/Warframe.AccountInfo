// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.ExtraModData
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

using Newtonsoft.Json;

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class ExtraModData
	{
		public ExtraModDataChallenge challenge { get; set; }

		public string compat { get; set; }

		public int lim { get; set; }

		public int lvlReq { get; set; }

		public int lvl { get; set; }

		public int rerolls { get; set; }

		public string pol { get; set; }

		public ExtraModDataBuff[] buffs { get; set; }

		public ExtraModDataCurse[] curses { get; set; }

		public bool IsRivenUnveiled() => challenge == null;

		public static ExtraModData DeserializeFromString(string json)
		{
			ExtraModData extraModData = new ExtraModData();
			if (!string.IsNullOrEmpty(json))
				extraModData = JsonConvert.DeserializeObject<ExtraModData>(json);
			return extraModData;
		}
	}
}

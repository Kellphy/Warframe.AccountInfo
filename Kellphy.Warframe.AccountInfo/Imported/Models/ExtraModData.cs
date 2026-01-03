// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.ExtraModData
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

using Newtonsoft.Json;

namespace AlecaFrameClientLib.Data.Types
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

		public bool IsRivenUnveiled() => this.challenge == null;

		public static ExtraModData DeserializeFromString(string json)
		{
			ExtraModData extraModData = new ExtraModData();
			if (!string.IsNullOrEmpty(json))
				extraModData = JsonConvert.DeserializeObject<ExtraModData>(json);
			return extraModData;
		}
	}
}

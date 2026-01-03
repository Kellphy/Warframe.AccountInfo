// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Drop
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

namespace AlecaFrameClientLib.Data.Types
{
	public class Drop
	{
		public DataRelic relic;

		public string location { get; set; }

		public string type { get; set; }

		public string rarity { get; set; }

		public float? chance { get; set; }

		public string rotation { get; set; }

		public bool IsRelic() => this.relic != null;
	}
}

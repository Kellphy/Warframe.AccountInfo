// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Drop
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A886CA06-AEA1-4DF9-9273-8423A987943C
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.63\NET\AlecaFrameClientLib.dll

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

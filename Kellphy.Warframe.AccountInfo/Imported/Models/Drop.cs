// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.Drop
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
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

// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Order
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AF6BFA32-0C17-442B-A131-E06BAE3E6F0A
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.66\NET\AlecaFrameClientLib.dll

using System;

namespace AlecaFrameClientLib.Data.Types
{
	public class Order
	{
		public int mod_rank = -69;
		public int amber_stars = -69;
		public int cyan_stars = -69;

		public bool visible { get; set; }

		public int platinum { get; set; }

		public int quantity { get; set; }

		public string order_type { get; set; }

		public User user { get; set; }

		public string platform { get; set; }

		public string region { get; set; }

		public DateTime creation_date { get; set; }

		public DateTime last_update { get; set; }

		public string id { get; set; }

		public string subtype { get; set; }
	}
}

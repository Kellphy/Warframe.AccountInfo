// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.BuySellPanelResponseItem
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AF6BFA32-0C17-442B-A131-E06BAE3E6F0A
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.66\NET\AlecaFrameClientLib.dll

using Newtonsoft.Json;

namespace AlecaFrameClientLib.Data.Types
{
	public class BuySellPanelResponseItem
	{
		public string playerName;
		public int platimun;
		public string specialValue = "";
		public int amount;
		[JsonIgnore]
		public Order order;

		public BuySellPanelResponseItem(Order order)
		{
			this.playerName = order.user.ingame_name;
			this.platimun = order.platinum;
			this.amount = order.quantity;
			this.order = order;
		}
	}
}

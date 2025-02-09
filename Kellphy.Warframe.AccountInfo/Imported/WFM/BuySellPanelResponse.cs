// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.BuySellPanelResponse
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AF6BFA32-0C17-442B-A131-E06BAE3E6F0A
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.66\NET\AlecaFrameClientLib.dll

using System.Collections.Generic;

namespace AlecaFrameClientLib.Data.Types
{
	public class BuySellPanelResponse
	{
		public List<BuySellPanelResponseItem> sellListings = new List<BuySellPanelResponseItem>();
		public List<BuySellPanelResponseItem> buyListings = new List<BuySellPanelResponseItem>();
		public BuySellPanelResponseSettings postingSettings = new BuySellPanelResponseSettings();
	}
}

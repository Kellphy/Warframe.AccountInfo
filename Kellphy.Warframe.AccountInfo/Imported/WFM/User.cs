// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.User
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AF6BFA32-0C17-442B-A131-E06BAE3E6F0A
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.66\NET\AlecaFrameClientLib.dll

using System;

namespace AlecaFrameClientLib.Data.Types
{
	public class User
	{
		public float reputation { get; set; }

		public string region { get; set; }

		public string avatar { get; set; }

		public DateTime last_seen { get; set; }

		public string ingame_name { get; set; }

		public string id { get; set; }

		public string status { get; set; }
	}
}

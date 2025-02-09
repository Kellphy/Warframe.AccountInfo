// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Utils.MyWebClient
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: AF6BFA32-0C17-442B-A131-E06BAE3E6F0A
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.66\NET\AlecaFrameClientLib.dll

using System;
using System.Net;
using System.Text;

namespace AlecaFrameClientLib.Utils
{
	public class MyWebClient : WebClient
	{
		public MyWebClient(int timeoutMS = 100000)
		{
			this.TimeoutMS = timeoutMS;
			this.Encoding = Encoding.UTF8;
		}

		public int TimeoutMS { get; }

		protected override WebRequest GetWebRequest(Uri uri)
		{
			HttpWebRequest webRequest = base.GetWebRequest(uri) as HttpWebRequest;
			if (uri.AbsoluteUri.Contains("warframe.market"))
				webRequest.UserAgent = "AlecaFrame_Client";
			webRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
			webRequest.Timeout = this.TimeoutMS;
			return (WebRequest)webRequest;
		}
	}
}

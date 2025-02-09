// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.StaticData
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A886CA06-AEA1-4DF9-9273-8423A987943C
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.63\NET\AlecaFrameClientLib.dll

using AlecaFrameClientLib.Utils;
using Newtonsoft.Json;
using System.Net;

namespace AlecaFrameClientLib
{
	public static class StaticData
	{
		public static string CDNdomain = "cdn.alecaframe.com";
		public static string baseDomain = "alecaframe.com";
		public static string APIdomain = "api." + StaticData.baseDomain;
		public static string PricesAPIHostname = "https://" + StaticData.APIdomain + "/prices";
		public static string RivenAPIHostname = "https://" + StaticData.APIdomain + "/rivens";
		public static string MLAPIHostname = "https://" + StaticData.APIdomain + "/ml";
		public static string LogAPIHostname = StaticData.APIdomain + "/log";
		public static string StatsAPIHostname = "https://stats." + StaticData.baseDomain;
		public static string CachedWFMAPIHostname = "wfmdirectcache." + StaticData.baseDomain + "/";
		public static string imageURLPrefix = "https://" + StaticData.CDNdomain + "/warframeData/img/";
		public static string logSettingsURL = "https://alecaframe---customcdndata.pages.dev/logSettings.txt";
		public static bool globalLogSettingsForceLogging = false;
		public static readonly int DELTA_BAD_ENOUGH_TO_LOG = 6;
		internal static readonly float MIN_DELTA_TO_CONSIDER_BAD_DETECTION = 7f;
		public static string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\AlecaFrame\\";
		public static bool HideFoundersPackItemsEnabled = false;
		public static bool DOFbypassEnabled = false;
		public static bool RelicOverlayEnabled = true;
		public static bool RelicRecommendationEnabled = true;
		public static bool WFMTakeModRankIntoAccount = true;
		public static ScalingMode WarframeScalingMode = ScalingMode.Full;
		public static DataHandler dataHandler;
		public static OverwolfWrapper overwolfWrappwer;
		public static string[] WarframePartsNotFoundThatShouldNotErrorOut = new string[2]
		{
	  "Anima",
	  "Animus"
		};
		public static string[] WeaponPartsNotFoundThatShouldNotErrorOut = new string[2]
		{
	  "/WeaponParts/InfTransformClawsWeaponBladeBlueprint",
	  "/WeaponParts/InfUziWeaponReceiverBlueprint"
		};
		public static string[] RelicsNotFoundThatShouldNotErrorOut = new string[0];
		public static string[] ModsNotFoundThatShouldNotErrorOut = new string[4]
		{
	  "/SentinelPrecepts/SwiftDeth",
	  "/SentinelPrecepts/Warrior",
	  "/SentinelPrecepts/TnCrossAttack",
	  "/SentinelPrecepts/BoomStick"
		};
		public static string[] MiscNotFoundThatShouldNotErrorOut = new string[0];
		public static string lastRelicLogFilePath;
		public static bool shouldLogLastRelic = false;
		public static int lastRelicLogWorstDelta = 0;
		public static string lastRelicLogText;
		public static byte[] lastDataKey = new byte[16]
		{
	  (byte) 76,
	  (byte) 69,
	  (byte) 79,
	  (byte) 45,
	  (byte) 65,
	  (byte) 76,
	  (byte) 69,
	  (byte) 67,
	  (byte) 9,
	  (byte) 69,
	  (byte) 79,
	  (byte) 45,
	  (byte) 65,
	  (byte) 76,
	  (byte) 69,
	  (byte) 67
		};
		public static byte[] lastDataIV = new byte[16]
		{
	  (byte) 49,
	  (byte) 50,
	  (byte) 70,
	  (byte) 71,
	  (byte) 66,
	  (byte) 51,
	  (byte) 54,
	  (byte) 45,
	  (byte) 76,
	  (byte) 69,
	  (byte) 51,
	  (byte) 45,
	  (byte) 113,
	  (byte) 61,
	  (byte) 57,
	  (byte) 0
		};
		public static float customScale = 1f;
		public static bool isFirstRunOnInstall = false;
		public static AutoResetEvent analyticsDataReadyEvent = new AutoResetEvent(false);
		public static bool analyticsDataReady = false;
		public static string overwolfID = "";
		public static string overwolfPromo = "";
		public static bool windowsNotificationsEnabled = false;
		public static bool discordNotificationsEnabled = false;
		public static string discordNotificationWebhook = "";
		public static string discordNotificationTemplate = "New in-game conversation from **<PLAYER_NAME>**";
		public static bool notificationOnlyBackground = true;
		public static string relicRecommendationOverlayFilters = "";
		public static TimeSpan timeAheadTimerNotifications = TimeSpan.FromMinutes(3.0);
		public static bool statsTabEnabled = true;
		public static bool notificationSoundsEnabled = true;
		public static Lazy<WFMItemList> LazyWfmItemData = new Lazy<WFMItemList>((Func<WFMItemList>)(() =>
		{
			return JsonConvert.DeserializeObject<WFMItemList>(new MyWebClient()
			{
				Proxy = ((IWebProxy)null),
				Headers = {
		  {
			HttpRequestHeader.UserAgent,
			"AlecaFrame_Client"
		  }
		}
			}.DownloadString("https://" + StaticData.CachedWFMAPIHostname + "/v1/items"));
		}));
		public static string discordWarframeMarketNotificationTemplate = "New <:warframe:771543444178337792> WFMarket message: **<WFM_MESSAGE>**";
		public static bool includeFormaLevelMasteryHelper = true;
		public static bool enableRivenOverlay = true;
		public static bool runOverwolfFunctionsAsync = true;

		public static string relicLogFolder => StaticData.saveFolder + "relicLogs/";

		public static string InClass(this string toSurround, string myClass, string tag = "span") => "<" + tag + " class=\"" + myClass + "\">" + toSurround + "</" + tag + ">";

		public static void Log(OverwolfWrapper.LogType logType, string data)
		{
			if (StaticData.overwolfWrappwer != null)
				StaticData.overwolfWrappwer.logInBackgroundCaller_PRIVATE(logType, data);
			else
				Console.WriteLine("[NULL LOG] [" + logType.ToString() + "] " + data);
		}
	}
}

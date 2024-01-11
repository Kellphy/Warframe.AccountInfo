// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.StaticData
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public static class StaticData
	{
		public static string CDNdomain = "cdn.alecaframe.com";
		public static string baseDomain = "alecaframe.com";
		public static string APIdomain = "api." + baseDomain;
		public static string PricesAPIHostname = "https://" + APIdomain + "/prices";
		public static string RivenAPIHostname = "https://" + APIdomain + "/rivens";
		public static string MLAPIHostname = "https://" + APIdomain + "/ml";
		public static string LogAPIHostname = APIdomain + "/log";
		public static string StatsAPIHostname = "https://stats." + baseDomain;
		public static string CachedWFMAPIHostname = "wfmdirectcache." + baseDomain + "/";
		public static string imageURLPrefix = "https://" + CDNdomain + "/warframeData/img/";
		public static string logSettingsURL = "https://alecaframe---customcdndata.pages.dev/logSettings.txt";
		public static bool globalLogSettingsForceLogging = false;
		public static readonly int DELTA_BAD_ENOUGH_TO_LOG = 6;
		internal static readonly float MIN_DELTA_TO_CONSIDER_BAD_DETECTION = 7f;
		public static string saveFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/AlecaFrame/";
		public static bool HideFoundersPackItemsEnabled = false;
		public static bool DOFbypassEnabled = false;
		public static bool RelicOverlayEnabled = true;
		public static bool RelicRecommendationEnabled = true;
		public static bool WFMTakeModRankIntoAccount = true;
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
	   76,
	   69,
	   79,
	   45,
	   65,
	   76,
	   69,
	   67,
	   9,
	   69,
	   79,
	   45,
	   65,
	   76,
	   69,
	   67
		};
		public static byte[] lastDataIV = new byte[16]
		{
	   49,
	   50,
	   70,
	   71,
	   66,
	   51,
	   54,
	   45,
	   76,
	   69,
	   51,
	   45,
	   113,
	   61,
	   57,
	   0
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

		public static string discordWarframeMarketNotificationTemplate = "New <:warframe:771543444178337792> WFMarket message: **<WFM_MESSAGE>**";
		public static bool includeFormaLevelMasteryHelper = true;
		public static bool enableRivenOverlay = true;

		public static string relicLogFolder => saveFolder + "relicLogs/";

		public static string InClass(this string toSurround, string myClass, string tag = "span") => "<" + tag + " class=\"" + myClass + "\">" + toSurround + "</" + tag + ">";

	}
}

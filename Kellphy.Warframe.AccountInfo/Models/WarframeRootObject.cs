namespace AlecaFrameClientLib.Data.Types
{
	public class WarframeRootObject
	{
		public string InventoryJSON = "";
		public Miscitem[] RawUpgrades = new Miscitem[0];
		public Miscitem[] FlavourItems = new Miscitem[0];
		public Miscitem[] MiscItems = new Miscitem[0];
		public Miscitem[] Recipes = new Miscitem[0];
		public Upgrade[] Upgrades = new Upgrade[0];
		public Miscitem[] LevelKeys = new Miscitem[0];

		public Xpinfo[] XPInfo;
		public Moapet[] MoaPets;
		public Kubrowpet[] KubrowPets;

		public int SubscribedToEmails { get; set; }

		public long RewardSeed { get; set; }

		public long RegularCredits { get; set; }

		public int PremiumCredits { get; set; }

		public int PremiumCreditsFree { get; set; }

		public int FusionPoints { get; set; }

		public int Version { get; set; }

		public int TradesRemaining { get; set; }

		public int DailyAffiliation { get; set; }

		public int DailyAffiliationPvp { get; set; }

		public int DailyAffiliationLibrary { get; set; }

		public int DailyFocus { get; set; }

		public int GiftsRemaining { get; set; }

		public int HandlerPoints { get; set; }

		public int ChallengesFixVersion { get; set; }

		public bool ReceivedStartingGear { get; set; }

		public int TrainingRetriesLeft { get; set; }

		public ILookup<string, Miscitem> MiscItemsLookup { get; set; }

		public int RandomUpgradesIdentified { get; set; }

		public string LastRegionPlayed { get; set; }

		public int PlayerLevel { get; set; }

		public string[] CompletedAlerts { get; set; }

		public string[] DeathMarks { get; set; }

		public string ActiveDojoColorResearch { get; set; }

		public bool ArchwingEnabled { get; set; }

		public string[] EquippedGear { get; set; }

		public object[] QualifyingInvasions { get; set; }

		public Miscitem[] FusionTreasures { get; set; }

		public int[] FactionScores { get; set; }

		public object[] PendingSpectreLoadouts { get; set; }

		public string[] CompletedSyndicates { get; set; }

		public string[] CompletedSorties { get; set; }

		public string ActiveAvatarImageType { get; set; }

		public string[] Wishlist { get; set; }

		public string[] EquippedEmotes { get; set; }

		public int DailyAffiliationCetus { get; set; }

		public int DailyAffiliationQuills { get; set; }

		public string FocusAbility { get; set; }

		public bool HasContributedToDojo { get; set; }

		public int FocusCapacity { get; set; }

		public int DailyAffiliationSolaris { get; set; }

		public int SubscribedToEmailsPersonalized { get; set; }

		public string ThemeStyle { get; set; }

		public int BountyScore { get; set; }

		public string[] LoginMilestoneRewards { get; set; }

		public int DailyAffiliationVentkids { get; set; }

		public int DailyAffiliationVox { get; set; }

		public string[] NodeIntrosCompleted { get; set; }

		public object[] RecentVendorPurchases { get; set; }

		public bool HWIDProtectEnabled { get; set; }

		public int CrewShipFusionPoints { get; set; }

		public bool PlayedParkourTutorial { get; set; }

		public int DailyAffiliationEntrati { get; set; }

		public int DailyAffiliationNecraloid { get; set; }

		public object[] ActiveLandscapeTraps { get; set; }

		public object[] CrewMembers { get; set; }

		public object[] RepVotes { get; set; }

		public object[] LeagueTickets { get; set; }

		public object[] Quests { get; set; }

		public object[] Robotics { get; set; }

		public object[] UsedDailyDeals { get; set; }

		public bool HasResetAccount { get; set; }

		public bool Harvestable { get; set; }

		public bool DeathSquadable { get; set; }

	}
}
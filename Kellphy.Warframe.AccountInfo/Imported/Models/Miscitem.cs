// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.Miscitem
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: A886CA06-AEA1-4DF9-9273-8423A987943C
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.62\NET\AlecaFrameClientLib.dll

namespace AlecaFrameClientLib.Data.Types
{
	public class Miscitem
	{
		public int ItemCount { get; set; }

		public string ItemType { get; set; }

		public Lastadded LastAdded { get; set; }

		public string UpgradeFingerprint { get; set; }

		public int XP { get; set; }

		public MiscItemItemId ItemId { get; set; }

		public bool IsWarframePart() => this.ItemType != null && this.ItemType.Contains("/WarframeRecipes/") && (!this.ItemType.Contains("Beacon") || !this.ItemType.Contains("Component"));

		public bool IsFactionOrBaro()
		{
			if (this.ItemType == null || this.ItemType.Contains("CephalonSuda/Pistols/CSDroidArray"))
				return false;
			return this.ItemType.Contains("/Prisma") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/SteelMeridian") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/ArbitersOfHexis") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/CephalonSuda") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/PerrinSequence") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/RedVeil") || this.ItemType.Contains("/Lotus/Weapons/Syndicates/NewLoka") || this.ItemType.Contains("/VoidTrader") || this.ItemType.Contains("/Lotus/Weapons/Corpus/LongGuns/CrpBFG/Vandal/VandalCrpBFG") || this.ItemType.Contains("/Lotus/Weapons/Tenno/Pistols/ConclaveLeverPistol/ConclaveLeverPistol");
		}

		public bool IsWeaponPart() => this.ItemType != null && !this.ItemType.Contains("/Weapons/Ostron") && !this.ItemType.Contains("/Weapons/Corpus") && !this.ItemType.Contains("TeamAmmoBlueprint") && !this.ItemType.Contains("/Weapons/Skins/") && (this.ItemType.Contains("/WeaponParts/") || this.ItemType.Contains("/SentinelRecipes/") && this.ItemType.Contains("Blueprint") || this.ItemType.Contains("/Weapons/") && this.ItemType.Contains("Blueprint"));

		public bool IsRelic() => this.ItemType != null && this.ItemType.Contains("/Projections/");

		public bool IsMisc() => this.ItemType != null && (this.ItemType.Contains("/Fusers/LegendaryModFuser") || this.ItemType == "/Lotus/Upgrades/Skins/Kubrows/Collars/PrimeKubrowCollarA" || this.ItemType.Contains("/Resources/Mechs/") || this.ItemType.Contains("/Items/Fish/") && !this.ItemType.Contains("Boot") || this.ItemType.Contains("/Lotus/Upgrades/Skins/") && this.ItemType.Contains("Helmet") || this.ItemType == "/Lotus/Types/Keys/Nightwave/GlassmakerBossFightKey" || this.ItemType.StartsWith("/Lotus/Types/Items/FusionTreasures") || this.IsScene());

		public bool IsScene() => this.ItemType != null && this.ItemType.StartsWith("/Lotus/Types/Items/MiscItems/PhotoboothTile");

		public bool IsLandingCraftPart() => this.ItemType != null && this.ItemType.Contains("/Lotus/Types/Recipes/LandingCraftRecipes/");

		public bool IsMod() => this.ItemType != null && !this.ItemType.Contains("/Beginner/") && (this.ItemType.Contains("/CosmeticEnhancers/Peculiars/") || this.ItemType.Contains("/Lotus/Upgrades/Mods/Railjack/") || !this.IsArcane());

		public bool IsArcane() => this.ItemType != null && !this.ItemType.Contains("/CosmeticEnhancers/Peculiars/") && this.ItemType.Contains("/Lotus/Upgrades/CosmeticEnhancers");

		public bool IsArchFramePart() => this.ItemType != null && this.ItemType.Contains("/Lotus/Types/Recipes/ArchwingRecipes/");

		public bool IsArchWeaponPart() => this.ItemType != null && this.ItemType.Contains("/Archwing/Primary/");

		public bool IsRivenMod() => this.ItemType != null && this.ItemType.StartsWith("/Lotus/Upgrades/Mods/Randomized/");
	}
}

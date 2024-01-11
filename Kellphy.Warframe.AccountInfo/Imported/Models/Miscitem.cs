// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.Miscitem
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class Miscitem
	{
		public int ItemCount { get; set; }

		public string ItemType { get; set; }

		public Lastadded LastAdded { get; set; }

		public string UpgradeFingerprint { get; set; }

		public int XP { get; set; }

		public MiscItemItemId ItemId { get; set; }

		public bool IsWarframePart() => ItemType != null && ItemType.Contains("/WarframeRecipes/") && (!ItemType.Contains("Beacon") || !ItemType.Contains("Component"));

		public bool IsFactionOrBaro()
		{
			if (ItemType == null || ItemType.Contains("CephalonSuda/Pistols/CSDroidArray"))
				return false;
			return ItemType.Contains("/Prisma") || ItemType.Contains("/Lotus/Weapons/Syndicates/SteelMeridian") || ItemType.Contains("/Lotus/Weapons/Syndicates/ArbitersOfHexis") || ItemType.Contains("/Lotus/Weapons/Syndicates/CephalonSuda") || ItemType.Contains("/Lotus/Weapons/Syndicates/PerrinSequence") || ItemType.Contains("/Lotus/Weapons/Syndicates/RedVeil") || ItemType.Contains("/Lotus/Weapons/Syndicates/NewLoka") || ItemType.Contains("/VoidTrader") || ItemType.Contains("/Lotus/Weapons/Corpus/LongGuns/CrpBFG/Vandal/VandalCrpBFG") || ItemType.Contains("/Lotus/Weapons/Tenno/Pistols/ConclaveLeverPistol/ConclaveLeverPistol");
		}

		public bool IsWeaponPart() => ItemType != null && !ItemType.Contains("/Weapons/Ostron") && !ItemType.Contains("/Weapons/Corpus") && !ItemType.Contains("TeamAmmoBlueprint") && !ItemType.Contains("/Weapons/Skins/") && (ItemType.Contains("/WeaponParts/") || ItemType.Contains("/SentinelRecipes/") && ItemType.Contains("Blueprint") || ItemType.Contains("/Weapons/") && ItemType.Contains("Blueprint"));

		public bool IsRelic() => ItemType != null && ItemType.Contains("/Projections/");

		public bool IsMisc() => ItemType != null && (ItemType.Contains("/Fusers/LegendaryModFuser") || ItemType == "/Lotus/Upgrades/Skins/Kubrows/Collars/PrimeKubrowCollarA" || ItemType.Contains("/Resources/Mechs/") || ItemType.Contains("/Items/Fish/") && !ItemType.Contains("Boot") || ItemType.Contains("/Lotus/Upgrades/Skins/") && ItemType.Contains("Helmet") || ItemType == "/Lotus/Types/Keys/Nightwave/GlassmakerBossFightKey" || IsScene());

		public bool IsScene() => ItemType != null && ItemType.StartsWith("/Lotus/Types/Items/MiscItems/PhotoboothTile");

		public bool IsLandingCraftPart() => ItemType != null && ItemType.Contains("/Lotus/Types/Recipes/LandingCraftRecipes/");

		public bool IsMod() => ItemType != null && !ItemType.Contains("/Beginner/") && (ItemType.Contains("/CosmeticEnhancers/Peculiars/") || ItemType.Contains("/Lotus/Upgrades/Mods/Railjack/") || !IsArcane());

		public bool IsArcane() => ItemType != null && !ItemType.Contains("/CosmeticEnhancers/Peculiars/") && ItemType.Contains("/Lotus/Upgrades/CosmeticEnhancers");

		public bool IsArchFramePart() => ItemType != null && ItemType.Contains("/Lotus/Types/Recipes/ArchwingRecipes/");

		public bool IsArchWeaponPart() => ItemType != null && ItemType.Contains("/Archwing/Primary/");

		public bool IsRivenMod() => ItemType != null && ItemType.StartsWith("/Lotus/Upgrades/Mods/Randomized/");
	}
}

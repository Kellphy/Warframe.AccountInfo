// Decompiled with JetBrains decompiler
// Type: AlecaFraceClientLib.Data.Types.ItemComponent
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 530002EE-180F-4309-87B7-42C94C23C74B
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.34\NET\AlecaFrameClientLib.dll

namespace Kellphy.Warframe.AccountInfo.Imported.Models
{
	public class ItemComponent
	{
		public BigItem isPartOf;

		public string uniqueName { get; set; }

		public string name { get; set; }

		public string description { get; set; }

		public int itemCount { get; set; }

		public string imageName { get; set; }

		public bool tradable { get; set; }

		public Drop[] drops { get; set; }

		public float[] damagePerShot { get; set; }

		public float totalDamage { get; set; }

		public float criticalChance { get; set; }

		public float criticalMultiplier { get; set; }

		public float procChance { get; set; }

		public float fireRate { get; set; }

		public int masteryReq { get; set; }

		public string productCategory { get; set; }

		public int slot { get; set; }

		public float accuracy { get; set; }

		public float omegaAttenuation { get; set; }

		public string noise { get; set; }

		public string trigger { get; set; }

		public int magazineSize { get; set; }

		public float reloadTime { get; set; }

		public int multishot { get; set; }

		public int ammo { get; set; }

		public Damagetypes damageTypes { get; set; }

		public int marketCost { get; set; }

		public string[] polarities { get; set; }

		public string projectile { get; set; }

		public string[] tags { get; set; }

		public string type { get; set; }

		public string wikiaThumbnail { get; set; }

		public string wikiaUrl { get; set; }

		public int disposition { get; set; }

		public int flight { get; set; }

		public int primeSellingPrice { get; set; }

		public int ducats { get; set; }

		public string releaseDate { get; set; }

		public string vaultDate { get; set; }

		public string estimatedVaultDate { get; set; }

		public int blockingAngle { get; set; }

		public int comboDuration { get; set; }

		public float followThrough { get; set; }

		public float range { get; set; }

		public int slamAttack { get; set; }

		public int slamRadialDamage { get; set; }

		public int slamRadius { get; set; }

		public int slideAttack { get; set; }

		public int heavyAttackDamage { get; set; }

		public int heavySlamAttack { get; set; }

		public int heavySlamRadialDamage { get; set; }

		public int heavySlamRadius { get; set; }

		public float windUp { get; set; }

		public float channeling { get; set; }

		public string stancePolarity { get; set; }

		public bool vaulted { get; set; }

		public bool excludeFromCodex { get; set; }

		public float statusChance { get; set; }

		public bool IsLandingCraftPart() => this.uniqueName.Contains("/Lotus/Types/Recipes/LandingCraftRecipes/");

		public string GetRealExternalName(bool alwaysProvideTradeablePartName = false)
		{
			string realExternalName = this.name;
			if (realExternalName == "Forma")
			{
				realExternalName = "Forma Blueprint";
			}
			else
			{
				if (realExternalName.Contains("Kavasa Prime") || this.name.Equals("Orokin Cell") || this.uniqueName.Contains("/Resources/") || this.uniqueName.Contains("/Types/Items/") || (double)this.fireRate > 0.0 || (double)this.reloadTime > 0.0 || this.uniqueName.Contains("/Resource/"))
					return this.name;
				if (this.isPartOf != null)
					realExternalName = this.isPartOf.name + " " + realExternalName;
			}
			if (realExternalName.Contains("Voidrig"))
				realExternalName = realExternalName.Replace("Voidrig Voidrig", "Voidrig");
			if (realExternalName.Contains("Bonewidow"))
				realExternalName = realExternalName.Replace("Bonewidow Bonewidow", "Bonewidow");
			if (realExternalName.Contains("War war"))
				realExternalName = realExternalName.Replace("War War", "War");
			if (realExternalName.Contains("War War"))
				realExternalName = realExternalName.Replace("War War", "War");
			if (realExternalName.Contains("Decurion decurion"))
				realExternalName = realExternalName.Replace("Decurion Decurion", "Decurion");
			if (realExternalName.Contains("Decurion Decurion"))
				realExternalName = realExternalName.Replace("Decurion Decurion", "Decurion");
			if (realExternalName == "Broken War Blade")
				realExternalName = "War Blade";
			if (realExternalName == "Broken War Hilt")
				realExternalName = "War Hilt";
			if (realExternalName.Contains("Dual Decurion") && !realExternalName.Contains("Blueprint"))
				realExternalName = realExternalName.Replace("Dual Decurion", "Decurion");
			if (this.isPartOf != null && !this.isPartOf.name.Contains("Ambassador"))
			{
				throw new NotImplementedException();
			}
			return realExternalName;
		}

		public class ItemComponentComparer : EqualityComparer<ItemComponent>
		{
			public override bool Equals(ItemComponent x, ItemComponent y) => x.uniqueName == y.uniqueName;

			public override int GetHashCode(ItemComponent obj) => obj.uniqueName.GetHashCode();
		}
	}
}

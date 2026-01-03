// Decompiled with JetBrains decompiler
// Type: AlecaFrameClientLib.Data.Types.ItemComponent
// Assembly: AlecaFrameClientLib, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 48846E38-6ED6-4519-B776-E43CAC265573
// Assembly location: C:\Users\virtu\AppData\Local\Overwolf\Extensions\afmcagbpgggkpdkokjhjkllpegnadmkignlonpjm\2.6.82\NET\AlecaFrameClientLib.dll

using AlecaFramePublicLib;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlecaFrameClientLib.Data.Types
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
				bool flag = false | this.isPartOf is DataWarframe;
				if (!flag && StaticData.dataHandler != null)
				{
					List<ExtendedCraftingRemoteDataItemComponent> dataItemComponentList1;
					if (StaticData.dataHandler?.tradeableCraftingPartsByUID?.TryGetValue(this.uniqueName, out dataItemComponentList1).GetValueOrDefault() ?? false)
					{
						if (dataItemComponentList1?.Count > 0)
						{
							int num1 = ((flag ? 1 : 0) | (dataItemComponentList1[0].componentType != ComponentType.SubBlueprint ? 0 : (dataItemComponentList1[0].tradeable ? 1 : 0))) != 0 ? 1 : 0;
							ExtendedCraftingRemoteDataItemComponent dataItemComponent = dataItemComponentList1[0];
							int num2 = dataItemComponent != null ? (dataItemComponent.components.Any<ExtendedCraftingRemoteDataItemComponent>((Func<ExtendedCraftingRemoteDataItemComponent, bool>)(p => p.componentType == ComponentType.SubBlueprint && p.tradeable)) ? 1 : 0) : 0;
							flag = (num1 | num2) != 0;
						}
					}
					else
					{
						List<ExtendedCraftingRemoteDataItemComponent> dataItemComponentList2;
						if (StaticData.dataHandler?.nonTradeableCraftingPartsByUID?.TryGetValue(this.uniqueName, out dataItemComponentList2).GetValueOrDefault() ?? false && dataItemComponentList2.Count > 0)
						{
							if (dataItemComponentList2?.Count > 0)
							{
								int num3 = ((flag ? 1 : 0) | (dataItemComponentList2[0].componentType != ComponentType.SubBlueprint ? 0 : (dataItemComponentList2[0].tradeable ? 1 : 0))) != 0 ? 1 : 0;
								ExtendedCraftingRemoteDataItemComponent dataItemComponent = dataItemComponentList2[0];
								int num4 = dataItemComponent != null ? (dataItemComponent.components.Any<ExtendedCraftingRemoteDataItemComponent>((Func<ExtendedCraftingRemoteDataItemComponent, bool>)(p => p.componentType == ComponentType.SubBlueprint && p.tradeable)) ? 1 : 0) : 0;
								flag = (num3 | num4) != 0;
							}
						}
					}
				}
				if (flag && !realExternalName.EndsWith("Blueprint"))
					realExternalName += " Blueprint";
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

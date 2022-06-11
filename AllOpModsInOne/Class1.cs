using Base.AI.Defs;
using AllOpModsInOne.SmallChanges;
using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.Levels;
using Base.UI;
using Base.Utils.Maths;
using Base.Utils.GameConsole;
using Code.PhoenixPoint.Tactical.Entities.Equipments;
using Harmony;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Common.Entities.Equipments;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsSharedData;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Common.Entities.RedeemableCodes;
using PhoenixPoint.Common.UI;
using PhoenixPoint.Geoscape.Entities.DifficultySystem;
using PhoenixPoint.Geoscape.Entities.Interception.Equipments;
using PhoenixPoint.Geoscape.Events.Eventus;
using PhoenixPoint.Geoscape.Levels;
using PhoenixPoint.Geoscape.Levels.Factions;
using PhoenixPoint.Tactical;
using PhoenixPoint.Tactical.AI;
using PhoenixPoint.Tactical.AI.Actions;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Animations;
using PhoenixPoint.Tactical.Entities.DamageKeywords;
using PhoenixPoint.Tactical.Entities.Effects;
using PhoenixPoint.Tactical.Entities.Effects.DamageTypes;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Statuses;
using PhoenixPoint.Tactical.Entities.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using System.IO;

namespace AllOpModsInOne
{            
    internal class ModConfig
    {
        public bool OpArmorAbilitiesEnabled = true;
		public bool VenomTorsoCanUseBothHands = true;
		public bool RemovableMutationsAndAugmentations = true;
		public bool UseMountedWeaponsManyTimesPerTurn = true;
		public bool UseMountedWeaponAndMechArmOnAugments = true;
		public bool FreeBionicRepair = true;
		public bool OpSoldierSkills = true;
		public bool RemoteControlBuff = true;
		public bool OpLivingWeapons = true;
		public bool ArchAngelRL1HasBlastRadius = true;
		public bool InstantResearch = true;
        public bool InstantManufacturing = true;
		public bool InstantFacilityConstruction = true;
		public bool FacilitiesDoNotRequirePower = true;
		public bool UnlockAllFacilities = true;
		public bool EverythingHalfOff = true;
		public bool ManufactureEverything = true;
		public bool StartWithEliteSoldiers = true;
        public bool DisableCorruption = true;
		public bool IncreaseSoldierInventorySlots = true;
		public bool UnlockAllBionics = true;
		public bool UnlockAllMutations = true;
		public bool MaxLevelSoldiers = true;
		public bool InfiniteSpecialPoints = true;
		public bool UnlockAllSpecializations = true;
        public bool Get10ThousandOfAllResources = true;
		public bool HealAllSoldiersAfterEveryMission = true;
		public bool NeverGetTiredOrExaustedAfterMissions = true;
		public bool TurnOnOtherAdjustments = true;
		public int VehicleBayAircraftSlots = 2;
		public int VehicleBayGroundVehicleSlots = 2;
		public int VehicleBayAircraftHealAmount = 48;
		public int VehicleBayGroundVehicleHealAmount = 20;
		public int Debug = 1;
	}
    public static class MyMod
    {
		internal static ModConfig Config;
		internal static string LogPath;
		internal static string ModDirectory;
		public static void HomeMod(Func<string, object, object> api = null)
        {
            MyMod.Config = api("config", null) as ModConfig ?? new ModConfig();
            HarmonyInstance.Create("AllOpModsInOne").PatchAll();
            api?.Invoke("log verbose", "Mod Initialised.");

            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
            SharedData Shared = GameUtl.GameComponent<SharedData>();

		    ModDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
		    LogPath = Path.Combine(ModDirectory, "AllOpModsInOne.log");
		    Logger.Initialize(LogPath, Config.Debug, ModDirectory, nameof(MyMod));

		    OpArmor.Change_Armor();
            MountedWeaponsMechArms.Change_Augmentations();
            InstantStuffAndDiscounts.Change_Time();
            EliteSoldiers.EliteSquad();
            Corruption.Change_Corruption();           
            SoldierSkills.Skills();
			HarmonyPatches.Change_Patches();
			SmallChanges.MutationsAndAugmentations.Change_PermanentAug();
			SmallChanges.OtherChanges.Change_Others();
			NotForNexuesRelease.MyStuff();
		}       
        // Token: 0x06000002 RID: 2 RVA: 0x00002058 File Offset: 0x00000258
        public static void MainMod(Func<string, object, object> api)
        {
            MyMod.HomeMod(api);
        }
    }	
}

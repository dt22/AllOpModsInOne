using AllOpModsInOne;
using Base.Core;
using Base.Defs;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Weapons;
using System.Linq;
using PhoenixPoint.Geoscape.Entities.Research.Reward;
using PhoenixPoint.Geoscape.Entities.Research;
using PhoenixPoint.Geoscape.Entities.PhoenixBases.FacilityComponents;

namespace AllOpModsInOne.SmallChanges
{
    internal class OtherChanges
    {
        public static void Change_Others()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
            ResearchDef atmosphiricAnalysis = Repo.GetAllDefs<ResearchDef>().FirstOrDefault(ged => ged.name.Equals("PX_AtmosphericAnalysis_ResearchDef"));
            PhoenixFacilityDef VehicleBay = Repo.GetAllDefs<PhoenixFacilityDef>().FirstOrDefault(ged => ged.name.Equals("VehicleBay_PhoenixFacilityDef"));
            VehicleSlotFacilityComponentDef VehicleBaySlotComponent = Repo.GetAllDefs<VehicleSlotFacilityComponentDef>().FirstOrDefault(ged => ged.name.Equals("E_Element0 [VehicleBay_PhoenixFacilityDef]"));

            if (MyMod.Config.OpLivingWeapons == true)
            {
                WeaponDef assRifle = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("PX_AcidAssaultRifle_WeaponDef"));
                WeaponDef Machinegun = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("PX_PoisonMachineGun_WeaponDef"));

                assRifle.DamagePayload.DamageKeywords[0].Value = 40;
                assRifle.DamagePayload.DamageKeywords[1].Value = 10;
                Machinegun.DamagePayload.DamageKeywords[0].Value = 35;
                Machinegun.DamagePayload.DamageKeywords[1].Value = 10;
                assRifle.DamagePayload.StopOnFirstHit = false;
                assRifle.DamagePayload.AutoFireShotCount = 7;
                assRifle.SpreadDegrees = 1.1f;
                Machinegun.DamagePayload.StopOnFirstHit = false;
                Machinegun.DamagePayload.AutoFireShotCount = 20;
                Machinegun.SpreadDegrees = 2.22704697f;
            }

            if (MyMod.Config.IncreaseSoldierInventorySlots == true)
            {
                BackpackFilterDef backpack = Repo.GetAllDefs<BackpackFilterDef>().FirstOrDefault(a => a.name.Equals("BackpackFilterDef"));
                backpack.MaxItems = 9;
            }
            
            if (MyMod.Config.RemoteControlBuff == true)
            {
                ApplyStatusAbilityDef remoteControl = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(a => a.name.Equals("ManualControl_AbilityDef"));
                remoteControl.ActionPointCost = 0.25f;
                remoteControl.WillPointCost = 2;
            }            
            
            if (MyMod.Config.ArchAngelRL1HasBlastRadius == true)
            {
                WeaponDef rl1 = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("NJ_HeavyRocketLauncher_WeaponDef"));
                WeaponDef rebuke = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("AC_Rebuke_WeaponDef"));
                ShootAbilityDef ShootRocket = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("LaunchRocket_ShootAbilityDef"));

                rl1.DamagePayload.DamageDeliveryType = DamageDeliveryType.Sphere;
                rl1.SpreadRadius = rebuke.SpreadRadius;
                rl1.SpreadDegrees = rebuke.SpreadDegrees;
                rl1.UseAimIK = false;
                rl1.AimTransform = rebuke.AimTransform;
                rl1.AimPoint = rebuke.AimPoint;
                rl1.DamagePayload.ParabolaHeightToLengthRatio = 0.3f;
                rl1.DamagePayload.ProjectileVisuals.TimeToLiveAfterStop = 1.5f;
                rl1.DamagePayload.ProjectileVisuals.ImpactNormalDisplacement = 0.5f;
                rl1.DamagePayload.ProjectileVisuals.HitEffect.Offset = 0.02f;
                rl1.DamagePayload.ProjectileVisuals.HitEffect.Alignment = PhoenixPoint.Common.Core.HitEffect.HitAlignment.SurfaceNormal;
                rl1.DamagePayload.StopOnFirstHit = false;
                rl1.DamagePayload.Range = 25;
                rl1.DamagePayload.AoeRadius = 3.5f;
                rl1.DamagePayload.ConeRadius = 1;
                rl1.DamagePayload.ProjectileOrigin = rebuke.DamagePayload.ProjectileOrigin;
                rl1.Abilities[0] = rebuke.Abilities[0];
                
            }
            
            if (MyMod.Config.UnlockAllFacilities == true)
            {
                atmosphiricAnalysis.Unlocks = new ResearchRewardDef[]
                {
                    atmosphiricAnalysis.Unlocks[0],
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("SYN_MistRepellers_ResearchDef_FacilityResearchRewardDef_0")),
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("NJ_Bionics1_ResearchDef_FacilityResearchRewardDef_0")),
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("ANU_AnuFungusFood_ResearchDef_FacilityResearchRewardDef_0")),
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("PX_CaptureTech_ResearchDef_FacilityResearchRewardDef_0")),
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("ANU_MutationTech_ResearchDef_FacilityResearchRewardDef_0")),
                    Repo.GetAllDefs<FacilityResearchRewardDef>().FirstOrDefault(a => a.name.Equals("PX_AntediluvianArchaeology_ResearchDef_FacilityResearchRewardDef_0")),
                };
            }
            
            if(MyMod.Config.TurnOnOtherAdjustments == true)
            {
                VehicleBaySlotComponent.AircraftSlots = MyMod.Config.VehicleBayAircraftSlots;
                VehicleBaySlotComponent.GroundVehicleSlots = MyMod.Config.VehicleBayGroundVehicleSlots;
                VehicleBaySlotComponent.AircraftHealAmount = MyMod.Config.VehicleBayAircraftHealAmount;
                VehicleBaySlotComponent.VehicleHealAmount = MyMod.Config.VehicleBayGroundVehicleHealAmount;
            }   
        }
    }
}


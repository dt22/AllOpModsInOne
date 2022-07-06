using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.UI;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Animations;
using PhoenixPoint.Tactical.Entities.Equipments;
using System.Linq;


namespace AllOpModsInOne
{
    internal class OpArmor
    {
        private static readonly DefRepository Repo = MyMod.Repo;
        public static void Change_Armor()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();

            ShootAbilityDef DD = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("DeadlyDuo_ShootAbilityDef")); 
            ShootAbilityDef RB = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("RageBurst_ShootAbilityDef"));

            DD.ExecutionsCount = 2;
            DD.AddFollowupAbilityStatusDef = null;
            DD.CharacterProgressionData = null;
            DD.OverrideEquipmentTrait = null;
            DD.TraitsToApply = new string[]
            {
                DD.TraitsToApply[0],
                DD.TraitsToApply[1],
                DD.TraitsToApply[2],
            };

            if (MyMod.Config.OpArmorAbilitiesEnabled == true)
            {
                        TacticalItemDef tentacleTorso = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Watcher_Torso_BodyPartDef"));
                        tentacleTorso.Abilities = new AbilityDef[]
                        {
                            tentacleTorso.Abilities[0],
                            tentacleTorso.Abilities[1],
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Arm_ParalyzeLimb_AbilityDef")),
                        };

                        TacticalItemDef regentorso = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Heavy_Torso_BodyPartDef"));
                        regentorso.Abilities = new AbilityDef[]
                        {
                            regentorso.Abilities[0],
                            regentorso.Abilities[1],
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_RightArm_Syphon_AdaptiveWeaponStatusDef")),
                        };

                        TacticalItemDef regenhelmet = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Heavy_Helmet_BodyPartDef"));
                        regenhelmet.Abilities = new AbilityDef[]
                        {
                            regenhelmet.Abilities[0],
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Head_Sonic_AbilityDef")),
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Head_GooStream_AbilityDef")),
                        };

                        TacticalItemDef venom = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Shooter_Torso_BodyPartDef"));
                        venom.Abilities = new AbilityDef[]
                        {
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Arm_PoisonWorm_AbilityDef")),
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Arm_FireWorm_AbilityDef")),
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Arm_AcidWorm_AbilityDef")),
                            Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Mutoid_Adapt_Arm_GooGrenade_AbilityDef")),
                        };                

                ItemDef shadowLegs = Repo.GetAllDefs<ItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Watcher_Legs_ItemDef"));
                shadowLegs.Abilities = new AbilityDef[] 
                {
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("PainChameleon_AbilityDef")),
                };

                TacticalItemDef watcherHelmet = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Watcher_Helmet_BodyPartDef"));
                watcherHelmet.Abilities = new AbilityDef[] 
                {
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("SenseLocate_AbilityDef")),
                };

                

                TacticalItemDef resisthelmet = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Shooter_Helmet_BodyPartDef"));
                resisthelmet.Abilities = new AbilityDef[] 
                {
                    resisthelmet.Abilities[0],
                    resisthelmet.Abilities[1],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("FireResistant_DamageMultiplierAbilityDef")),
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("ExpertLightWeapons_AbilityDef")),
                };

                TacticalItemDef juggTorso = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("NJ_Jugg_BIO_Torso_BodyPartDef"));
                juggTorso.Abilities = new AbilityDef[] 
                {
                    juggTorso.Abilities[0],
                    juggTorso.Abilities[1],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("GrenadeSpam_ShootAbilityDef")),
                };

                TacticalItemDef distruptorHead = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("NJ_Exo_BIO_Helmet_BodyPartDef"));
                distruptorHead.Abilities = new AbilityDef[]
                {
                    distruptorHead.Abilities[0],
                    distruptorHead.Abilities[1],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("DeadlyDuo_ShootAbilityDef")),
                    //Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("DeadlyDuo_FollowUp_ShootAbilityDef")),
                };

                TacticalItemDef stealthHelmet = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("SY_Shinobi_BIO_Helmet_BodyPartDef"));
                TacticalItemDef stealthTorso = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("SY_Shinobi_BIO_Torso_BodyPartDef"));
                TacticalItemDef stealthLegs = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("SY_Shinobi_BIO_Legs_ItemDef"));

                stealthHelmet.Abilities = new AbilityDef[]
                {
                    stealthHelmet.Abilities[0],
                    stealthHelmet.Abilities[1],
                    stealthHelmet.Abilities[2],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("MindControlImmunity_AbilityDef")),
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("NeuralDisruption_AbilityDef")),
                };
                stealthTorso.Abilities = new AbilityDef[]
                {
                    stealthTorso.Abilities[0],
                    stealthTorso.Abilities[1],
                    stealthTorso.Abilities[2],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("DemolitionMan_AbilityDef")),
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("HeavyLifter_AbilityDef")),
                };
                stealthLegs.Abilities = new AbilityDef[]
                {
                    stealthLegs.Abilities[0],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("GooImmunity_AbilityDef")),
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("SafeLanding_AbilityDef")),
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Exo_Leap_AbilityDef")),
                };

                ItemDef agileLegs = Repo.GetAllDefs<ItemDef>().FirstOrDefault(a => a.name.Equals("AN_Berserker_Shooter_Legs_ItemDef"));           
                    agileLegs.Abilities = new AbilityDef[] {
                    agileLegs.Abilities[0],
                    agileLegs.Abilities[1],
                    Repo.GetAllDefs<AbilityDef>().FirstOrDefault(a => a.name.Equals("Dash_AbilityDef")),
                };
            }          
        }
        //public static void Create_Reinforcements()
        //{
        //    ShootAbilityDef DD = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("DeadlyDuo_ShootAbilityDef"));
        //    string skillName4 = "OPDeadlyDuo_AbilityDef";
        //    SpawnActorAbilityDef source4 = Repo.GetAllDefs<SpawnActorAbilityDef>().FirstOrDefault(p => p.name.Equals("RageBurst_RageBurstInConeAbilityDef"));
        //    SpawnActorAbilityDef ODD = Helper.CreateDefFromClone(
        //        source4,
        //        "F128D091-E92B-4765-82BA-6F46E654E125",
        //        skillName4);
        //    ODD.ViewElementDef = Helper.CreateDefFromClone(
        //        source4.ViewElementDef,
        //       "AFF08D93-FD49-47F7-A05A-D9A246684248",
        //       skillName4);
        //    ODD.CharacterProgressionData = Helper.CreateDefFromClone(
        //        source4.CharacterProgressionData,
        //       "4D9DA012-78BA-4A6B-B84D-6288161986D0",
        //       skillName4);
        //    ODD.SceneViewElementDef = Helper.CreateDefFromClone(
        //        source4.SceneViewElementDef,
        //       "4D9DA012-78BA-4A6B-B84D-6288161986D0",
        //       skillName4);
        //
        //    ODD.CharacterProgressionData = null;
        //
        //    ODD.ViewElementDef.DisplayName1 = new LocalizedTextBind("Reinforcements", true);
        //    ODD.ViewElementDef.Description = new LocalizedTextBind("Call on the exalted to reinforce your squad", true);
        //    ODD.ActionPointCost = 1;
        //    ODD.WillPointCost = 8;
        //    ODD.UsesPerTurn = 1;
        //
        //    //SpawnActor.ReinforcementsSettings[0].CharacterTagDef = assaultTag;
        //    //SpawnActor.ReinforcementsSettings[1].CharacterTagDef = ExaltedTag;
        //    //SpawnActor.ViewElementDef.DisplayName1 = new LocalizedTextBind("Reinforcements", true);
        //    //SpawnActor.ViewElementDef.Description = new LocalizedTextBind("Reinforce your squad", true);
        //    //SpawnActor.EventOnActivate.CullFilters = new Base.Eventus.BaseEventFilterDef[]
        //    //{
        //    //    SpawnActor.EventOnActivate.CullFilters[0],
        //    //};
        //    //reinforcementsCall.EventOnActivate = new TacticalEventDef();
        //    foreach (TacActorSimpleAbilityAnimActionDef animActionDef in Repo.GetAllDefs<TacActorSimpleAbilityAnimActionDef>().Where(aad => aad.name.Contains("Soldier_Utka_AnimActionsDef")))
        //    {
        //        if (animActionDef.AbilityDefs != null && !animActionDef.AbilityDefs.Contains(ODD))
        //        {
        //            animActionDef.AbilityDefs = animActionDef.AbilityDefs.Append(ODD).ToArray();
        //        }
        //    }
        //}
    }
}
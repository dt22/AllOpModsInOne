using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.UI;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Animations;
using PhoenixPoint.Tactical.Entities.Effects.ApplicationConditions;
using PhoenixPoint.Tactical.Entities.Effects.DamageTypes;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Statuses;
using System.Linq;


namespace AllOpModsInOne
{
    internal class PromoSkinArmor
    {
        private static readonly DefRepository Repo = MyMod.Repo;
        private static readonly SharedData Shared = MyMod.Shared;
        public static void Create_PromoSkinArmor()
        {
            string skillName2 = "BonusArmor2_AbilityDef";
            ApplyEffectAbilityDef source2 = Repo.GetAllDefs<ApplyEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("Acheron_RestorePandoranArmor_AbilityDef"));
            ItemSlotStatsModifyStatusDef source2Status = Repo.GetAllDefs<ItemSlotStatsModifyStatusDef>().FirstOrDefault(p => p.name.Equals("E_Status [Acheron_RestorePandoranArmor_AbilityDef]"));
            ApplyEffectAbilityDef addarmour = Helper.CreateDefFromClone(
                source2,
                "251E62C2-F652-481E-B043-A2B1D6525B75",
                skillName2);
            addarmour.ViewElementDef = Helper.CreateDefFromClone(
                source2.ViewElementDef,
               "8E49AFB8-E450-49A2-A732-9231EE8CDBA2",
               skillName2);
            addarmour.CharacterProgressionData = Helper.CreateDefFromClone(
                source2.CharacterProgressionData,
               "3DE5F496-7515-4975-AE3C-8E68AE35DF0C",
               skillName2);
            addarmour.EffectDef = Helper.CreateDefFromClone(
                source2.EffectDef,
               "E31F7344-8F19-4AAE-8FE7-141865E34760",
               $"E_Effect [{skillName2}]");
            //StatusEffectDef addarmourEffect = Helper.CreateDefFromClone(
            //    addarmour.EffectDef as StatusEffectDef,
            //   "E31F7344-8F19-4AAE-8FE7-141865E34760",
            //   "E_Effect [BonusArmor_AbilityDef]");
            //ItemSlotStatsModifyStatusDef addarmourStatus = Helper.CreateDefFromClone(
            //    addarmourEffect.StatusDef as ItemSlotStatsModifyStatusDef,
            //   "5262FA8D-5F25-44C2-A50F-3B32F39CC978",
            //   "E_Effect [BonusArmor_AbilityDef]");

            ItemSlotStatsModifyStatusDef addarmourStatus = Helper.CreateDefFromClone(
                source2Status as ItemSlotStatsModifyStatusDef,
               "5262FA8D-5F25-44C2-A50F-3B32F39CC978",
               $"E_Status [{skillName2}]");

            StatusEffectDef addarmourEffect = (StatusEffectDef)addarmour.EffectDef;
            addarmourEffect.StatusDef = addarmourStatus;

            //addarmour.EffectDef = addarmourEffect;
            //addarmourEffect.StatusDef = addarmourStatus;

            foreach (TacActorSimpleAbilityAnimActionDef animActionDef in Repo.GetAllDefs<TacActorSimpleAbilityAnimActionDef>().Where(aad => aad.name.Contains("Soldier_Utka_AnimActionsDef")))
            {
                if (animActionDef.AbilityDefs != null && !animActionDef.AbilityDefs.Contains(addarmour))
                {
                    animActionDef.AbilityDefs = animActionDef.AbilityDefs.Append(addarmour).ToArray();
                }
            }



            addarmour.TargetingDataDef.Origin.TargetTags = new GameTagsList
            {
                Repo.GetAllDefs<GameTagDef>().FirstOrDefault(a => a.name.Contains("Human_TagDef"))
            };

            addarmourStatus.StatsModifications = new ItemSlotStatsModifyStatusDef.ItemSlotModification[]
            {
                new ItemSlotStatsModifyStatusDef.ItemSlotModification()
            {
                Type = ItemSlotStatsModifyStatusDef.StatType.Armour,
                ModificationType = StatModificationType.Add,
                Value = 10,
            },
            
            new ItemSlotStatsModifyStatusDef.ItemSlotModification()
            {
                Type = ItemSlotStatsModifyStatusDef.StatType.Armour,
                ModificationType = StatModificationType.AddMax,
                Value = 10,
            },
            };

            addarmour.ViewElementDef.DisplayName1 = new LocalizedTextBind("Armor Buff", true);
            addarmour.ViewElementDef.Description = new LocalizedTextBind("Add +10 armor to allies for the duration of the mission", true);
            addarmour.UsesPerTurn = 1;
            addarmour.WillPointCost = 4;


            string skillName3 = "GoldTorsoOilCrab_AbilityDef";
            DeathBelcherAbilityDef source3 = Repo.GetAllDefs<DeathBelcherAbilityDef>().FirstOrDefault(p => p.name.Equals("Oilcrab_Die_DeathBelcher_AbilityDef"));
            DeathBelcherAbilityDef oilCrab = Helper.CreateDefFromClone(
                source3,
                "54CD9E74-7F1D-4D84-8316-FCBF56C0D38D",
                skillName3);

            AddAbilityStatusDef oilCrabStatus = Repo.GetAllDefs<AddAbilityStatusDef>().FirstOrDefault(a => a.name.Equals("OilCrab_AddAbilityStatusDef"));
            ActorHasTagEffectConditionDef oilCrabCondition = (ActorHasTagEffectConditionDef)oilCrabStatus.ApplicationConditions[0];
            oilCrabCondition.GameTag = Repo.GetAllDefs<GameTagDef>().FirstOrDefault(a => a.name.Equals("SmallGeyser_GameTagDef"));
            oilCrabCondition.HasTag = false;

            

            
            TacticalItemDef assaultTorsoGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Torso_Gold_BodyPartDef"));
            TacticalItemDef assaultHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Helmet_Gold_BodyPartDef"));
            TacticalItemDef SniperHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Sniper_Helmet_Gold_BodyPartDef"));
            TacticalItemDef HeavyTorsoGoldGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Heavy_Torso_Gold_BodyPartDef"));
            
            TacCharacterDef Exalted = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(p => p.name.Equals("AN_Exalted_TacCharacterDef"));
            ClassTagDef assaultTag = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(p => p.name.Equals("Assault_ClassTagDef"));
            ClassTagDef ExaltedTag = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(p => p.name.Equals("Heavy_ClassTagDef"));

            

            string skillName4 = "HumanReinforcements2_AbilityDef";
            SpawnActorAbilityDef source4 = Repo.GetAllDefs<SpawnActorAbilityDef>().FirstOrDefault(p => p.name.Equals("Decoy_AbilityDef"));
            SpawnActorAbilityDef SpawnActor = Helper.CreateDefFromClone(
                source4,
                "F128D091-E92B-4765-82BA-6F46E654E125",
                skillName4);
            SpawnActor.ViewElementDef = Helper.CreateDefFromClone(
                source4.ViewElementDef,
               "AFF08D93-FD49-47F7-A05A-D9A246684248",
               skillName4);
            SpawnActor.CharacterProgressionData = Helper.CreateDefFromClone(
                source4.CharacterProgressionData,
               "4D9DA012-78BA-4A6B-B84D-6288161986D0",
               skillName4);



            SpawnActor.CharacterProgressionData = null;
            SpawnActor.TacCharacterDef = Exalted;
            SpawnActor.ActorComponentSetDef = Exalted.ComponentSetDef;
            
            SpawnActor.ActorTags = new GameTagDef[]
            {
                ExaltedTag,
            };
            
            SpawnActor.UseSelfAsTemplate = false;
            SpawnActor.TacCharacterDef = Exalted;
            SpawnActor.ActorComponentSetDef = Exalted.ComponentSetDef;
            SpawnActor.ViewElementDef.DisplayName1 = new LocalizedTextBind("Reinforcements", true);
            SpawnActor.ViewElementDef.Description = new LocalizedTextBind("Call on the exalted to reinforce your squad", true);
            SpawnActor.ActionPointCost = 1;
            SpawnActor.WillPointCost = 8;
            SpawnActor.UsesPerTurn = 1;

            //SpawnActor.ReinforcementsSettings[0].CharacterTagDef = assaultTag;
            //SpawnActor.ReinforcementsSettings[1].CharacterTagDef = ExaltedTag;
            //SpawnActor.ViewElementDef.DisplayName1 = new LocalizedTextBind("Reinforcements", true);
            //SpawnActor.ViewElementDef.Description = new LocalizedTextBind("Reinforce your squad", true);
            //SpawnActor.EventOnActivate.CullFilters = new Base.Eventus.BaseEventFilterDef[]
            //{
            //    SpawnActor.EventOnActivate.CullFilters[0],
            //};

            
            //reinforcementsCall.EventOnActivate = new TacticalEventDef();

            foreach (TacActorSimpleAbilityAnimActionDef animActionDef in Repo.GetAllDefs<TacActorSimpleAbilityAnimActionDef>().Where(aad => aad.name.Contains("Soldier_Utka_AnimActionsDef")))
            {
                if (animActionDef.AbilityDefs != null && !animActionDef.AbilityDefs.Contains(SpawnActor))
                {
                    animActionDef.AbilityDefs = animActionDef.AbilityDefs.Append(SpawnActor).ToArray();
                }
            }            
        }
        public static void AddAbilities()
        {
            ApplyEffectAbilityDef addarmour = Repo.GetAllDefs<ApplyEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("BonusArmor2_AbilityDef"));
            DeathBelcherAbilityDef oilCrab = Repo.GetAllDefs<DeathBelcherAbilityDef>().FirstOrDefault(p => p.name.Equals("GoldTorsoOilCrab_AbilityDef"));
            SpawnActorAbilityDef SpawnActor = Repo.GetAllDefs<SpawnActorAbilityDef>().FirstOrDefault(p => p.name.Equals("HumanReinforcements2_AbilityDef"));
            TacticalItemDef assaultTorsoGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Torso_Gold_BodyPartDef"));
            TacticalItemDef assaultHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Helmet_Gold_BodyPartDef"));
            TacticalItemDef SniperHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Sniper_Helmet_Gold_BodyPartDef"));
            TacticalItemDef SniperTorsoGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Sniper_Torso_Gold_BodyPartDef"));
            TacticalItemDef HeavyTorsoGoldGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Heavy_Torso_Gold_BodyPartDef"));
            ApplyStatusAbilityDef SenseLocate = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("SenseLocate_AbilityDef"));                        
            ApplyStatusAbilityDef crystalStacks = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("CrystalStacks_DamageAmplification_AbilityDef"));
            ApplyDamageEffectAbilityDef viralAreaAttack = Repo.GetAllDefs<ApplyDamageEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("ViralAreaAttack_ApplyDamageEffect_AbilityDef"));

            foreach (TacActorSimpleAbilityAnimActionDef animActionDef in Repo.GetAllDefs<TacActorSimpleAbilityAnimActionDef>().Where(aad => aad.name.Contains("Soldier_Utka_AnimActionsDef")))
            {
                if (animActionDef.AbilityDefs != null && !animActionDef.AbilityDefs.Contains(viralAreaAttack))
                {
                    animActionDef.AbilityDefs = animActionDef.AbilityDefs.Append(viralAreaAttack).ToArray();
                }
            }

            if (MyMod.Config.GoldArmorSkinsHaveSpecialAbilities)
            {
                assaultTorsoGold.Abilities = new AbilityDef[]
                {
                    oilCrab,
                };
                assaultHelmetGold.Abilities = new AbilityDef[]
                {
                    SenseLocate,
                };                        
                SniperHelmetGold.Abilities = new AbilityDef[]
                {
                    addarmour,
                    SpawnActor,
                };               
                HeavyTorsoGoldGold.Abilities = new AbilityDef[]
                 {
                     crystalStacks,
                     viralAreaAttack,
                 };                                                    
            }
        }
    }
}

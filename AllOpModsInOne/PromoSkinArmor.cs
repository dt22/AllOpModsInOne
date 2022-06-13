using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.UI;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
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
            string skillName2 = "BonusArmor_AbilityDef";
            ApplyEffectAbilityDef source2 = Repo.GetAllDefs<ApplyEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("Acheron_RestorePandoranArmor_AbilityDef"));
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
            StatusEffectDef addarmourEffect = Helper.CreateDefFromClone(
                source2.EffectDef as StatusEffectDef,
               "E31F7344-8F19-4AAE-8FE7-141865E34760",
               "E_Effect [BonusArmor_AbilityDef]");
            ItemSlotStatsModifyStatusDef addarmourStatus = Helper.CreateDefFromClone(
                addarmourEffect.StatusDef as ItemSlotStatsModifyStatusDef,
               "5262FA8D-5F25-44C2-A50F-3B32F39CC978",
               "E_Effect [BonusArmor_AbilityDef]");

            addarmour.EffectDef = addarmourEffect;
            addarmourEffect.StatusDef = addarmourStatus;

            addarmour.TargetingDataDef.Origin.TargetTags = null;
          
            addarmourStatus.StatsModifications = new ItemSlotStatsModifyStatusDef.ItemSlotModification[]
            {
                new ItemSlotStatsModifyStatusDef.ItemSlotModification()
                {
                    Type = ItemSlotStatsModifyStatusDef.StatType.Armour,
                    ModificationType = StatModificationType.Add,
                    Value = 10,
                },           
            };

            string skillName3 = "GoldTorsoOilCrab_AbilityDef";
            DeathBelcherAbilityDef source3 = Repo.GetAllDefs<DeathBelcherAbilityDef>().FirstOrDefault(p => p.name.Equals("Oilcrab_Die_DeathBelcher_AbilityDef"));
            DeathBelcherAbilityDef oilCrab = Helper.CreateDefFromClone(
                source3,
                "54CD9E74-7F1D-4D84-8316-FCBF56C0D38D",
                skillName3);

            AddAbilityStatusDef oilCrabStatus = Repo.GetAllDefs<AddAbilityStatusDef>().FirstOrDefault(a => a.name.Equals("OilCrab_AddAbilityStatusDef"));
            ActorHasTagEffectConditionDef oilCrabCondition = (ActorHasTagEffectConditionDef)oilCrabStatus.ApplicationConditions[0];
            TacticalItemDef assaultTorsoGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Torso_Gold_BodyPartDef"));
            TacticalItemDef assaultHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Assault_Helmet_Gold_BodyPartDef"));
            TacticalItemDef SniperHelmetGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Sniper_Helmet_Gold_BodyPartDef"));
            TacticalItemDef HeavyTorsoGoldGold = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(p => p.name.Equals("PX_Heavy_Torso_Gold_BodyPartDef"));
            ApplyStatusAbilityDef SenseLocate = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("SenseLocate_AbilityDef"));
            ApplyStatusAbilityDef crystalStacks = Repo.GetAllDefs<ApplyStatusAbilityDef>().FirstOrDefault(p => p.name.Equals("CrystalStacks_DamageAmplification_AbilityDef"));
            ApplyDamageEffectAbilityDef viralAreaAttack = Repo.GetAllDefs<ApplyDamageEffectAbilityDef>().FirstOrDefault(p => p.name.Equals("ViralAreaAttack_ApplyDamageEffect_AbilityDef"));
            TacCharacterDef Exalted = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(p => p.name.Equals("AN_Exalted_TacCharacterDef"));

            oilCrabCondition.GameTag = Repo.GetAllDefs<GameTagDef>().FirstOrDefault(a => a.name.Equals("SmallGeyser_GameTagDef"));
            oilCrabCondition.HasTag = false;

            string skillName4 = "HumanReinforcements_AbilityDef";
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

            SpawnActor.TacCharacterDef = Exalted;
            SpawnActor.ActorComponentSetDef = Exalted.ComponentSetDef;
            SpawnActor.ActorTags = null;
            SpawnActor.UseSelfAsTemplate = false;
            SpawnActor.ViewElementDef.DisplayName1 = new LocalizedTextBind("Reinforcements", true);
            SpawnActor.ViewElementDef.Description = new LocalizedTextBind("Call on the exalted to reinforce your squad", true);

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
                    SpawnActor
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

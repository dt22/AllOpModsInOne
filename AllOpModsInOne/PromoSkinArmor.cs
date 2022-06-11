using Base.Core;
using Base.Defs;
using Base.Entities.Abilities;
using Base.Entities.Effects;
using Base.Entities.Statuses;
using Base.UI;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Tactical.Entities.Abilities;
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
        }

    }
}

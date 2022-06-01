using Base.Core;
using Base.Defs;
using PhoenixPoint.Common.Entities.Addons;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Weapons;
using System.Linq;

namespace AllOpModsInOne
{
    internal class NotForNexuesRelease
    {
        public static void MyStuff()
        {
            
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
            
            WeaponDef tobiasWestGun = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("NJ_TobiasWestGun_WeaponDef"));
            ClassTagDef allClass = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(a => a.name.Equals("AllClasses_ClassTagDef"));
            ClassTagDef assaultClass = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(a => a.name.Equals("Assault_ClassTagDef"));
            ItemTypeTagDef handGunItemTag = Repo.GetAllDefs<ItemTypeTagDef>().FirstOrDefault(a => a.name.Equals("HandgunItem_TagDef"));
            ClassProficiencyAbilityDef assaultProficiency = Repo.GetAllDefs<ClassProficiencyAbilityDef>().FirstOrDefault(a => a.name.Equals("Assault_ClassProficiency_AbilityDef"));

            TacCharacterDef arthron = Repo.GetAllDefs<TacCharacterDef>().FirstOrDefault(a => a.name.Equals("Crabman1_Basic_AlienMutationVariationDef"));
            TacticalItemDef arthronLeftArmGL = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_LeftArm_Grenade_BodyPartDef"));
            TacticalItemDef arthronRightEliteViralGun = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_RightArm_Viral_EliteGun_BodyPartDef"));
            TacticalItemDef arthronRightArmEliteGun = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_RightArm_EliteGun_BodyPartDef"));
            WeaponDef arthronSpitHead = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(a => a.name.Equals("Crabman_Head_EliteSpitter_WeaponDef"));
            TacticalItemDef arthronLegsEAgile = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_Legs_EliteAgile_ItemDef"));
            TacticalItemDef arthronLeftLegEAgile = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_LeftLeg_EliteAgile_BodyPartDef"));
            TacticalItemDef arthronLegsEArmor = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_Legs_EliteArmoured_ItemDef"));
            TacticalItemDef arthronRightLegEArmor = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_RightLeg_EliteArmoured_BodyPartDef"));
            AddonSlotDef arthronLeftArmSlot = Repo.GetAllDefs<AddonSlotDef>().FirstOrDefault(a => a.name.Equals("Crabman_LeftArm_SlotDef"));
            AddonSlotDef arthronLeftHandSlot = Repo.GetAllDefs<AddonSlotDef>().FirstOrDefault(a => a.name.Equals("Crabman_LeftHand_SlotDef"));
            TacticalItemDef arthronEliteCarapace = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("Crabman_EliteTorso_BodyPartDef"));

            //arthronRightArmEliteGun.RequiredSlotBinds = new AddonDef.RequiredSlotBind[]
            //{
            //        new AddonDef.RequiredSlotBind()
            //        {
            //            RequiredSlot = arthronLeftArmSlot,
            //            GameTagFilter = null,
            //        },
            //};
            //
            //arthronRightArmEliteGun.ProvidedSlots = new AddonDef.ProvidedSlotBind[]
            //{
            //        new AddonDef.ProvidedSlotBind()
            //        {
            //            ProvidedSlot = arthronLeftHandSlot,
            //            AttachmentPointName = arthronLeftArmGL.ProvidedSlots[0].AttachmentPointName,
            //        },
            //};
            //
            //arthronLegsEAgile.SubAddons[1].SubAddon = arthronRightLegEArmor;
            //
            //arthron.Data.BodypartItems = new ItemDef[]
            //{
            //        arthronSpitHead,
            //        arthronRightEliteViralGun,
            //        arthronEliteCarapace,
            //        arthronLegsEAgile,
            //        arthronRightArmEliteGun,
            //};
            //
            //
            //assaultProficiency.ClassTags = new GameTagsList
            //{
            //    assaultProficiency.ClassTags[0],
            //    assaultProficiency.ClassTags[1],
            //    assaultProficiency.ClassTags[2],
            //    assaultProficiency.ClassTags[3],
            //    handGunItemTag,
            //};
            
            tobiasWestGun.Tags = new GameTagsList
                {
                    tobiasWestGun.Tags[0],
                    tobiasWestGun.Tags[1],
                    tobiasWestGun.Tags[2],
                    handGunItemTag,
                    tobiasWestGun.Tags[4],
                    tobiasWestGun.Tags[5],
                    allClass,
                    assaultClass,
                };
            
        }
    }
}

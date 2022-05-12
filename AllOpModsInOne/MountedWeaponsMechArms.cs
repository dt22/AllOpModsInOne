using System.Linq;
using Base.Defs;
using PhoenixPoint.Tactical.Entities.Weapons;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Abilities;
using Base.Core;
using PhoenixPoint.Common.Entities.Addons;
using PhoenixPoint.Common.Entities.GameTagsTypes;
using PhoenixPoint.Tactical.Entities;

namespace AllOpModsInOne
{
    internal class MountedWeaponsMechArms
    {
        public static void Change_Augmentations()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();

            if (MyMod.Config.UseMountedWeaponAndMechArmOnAugments == true)
            {               
                TacticalItemDef jugg = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("NJ_Jugg_BIO_Torso_BodyPartDef"));
                TacticalItemDef shin = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("SY_Shinobi_BIO_Torso_BodyPartDef"));
                TacticalItemDef neural = Repo.GetAllDefs<TacticalItemDef>().FirstOrDefault(a => a.name.Equals("NJ_Exo_BIO_Torso_BodyPartDef"));
                ClassTagDef heavyclass = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(a => a.name.Equals("Heavy_ClassTagDef"));
                ClassTagDef techclass = Repo.GetAllDefs<ClassTagDef>().FirstOrDefault(a => a.name.Equals("Technician_ClassTagDef"));
                AddonSlotDef backpack = Repo.GetAllDefs<AddonSlotDef>().FirstOrDefault(a => a.name.Equals("Human_BackPack_SlotDef"));


                jugg.Tags.Add(heavyclass);
                jugg.Tags.Add(techclass);
                shin.Tags.Add(heavyclass);
                shin.Tags.Add(techclass);

                jugg.ProvidedSlots = neural.ProvidedSlots;
                shin.ProvidedSlots = neural.ProvidedSlots;
            }

            if (MyMod.Config.UseMountedWeaponsManyTimesPerTurn == true)
            {
                ShootAbilityDef Rocket = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("LaunchRocket_ShootAbilityDef"));
                ShootAbilityDef pxLaser = Repo.GetAllDefs<ShootAbilityDef>().FirstOrDefault(a => a.name.Equals("LaserArray_ShootAbilityDef"));

                Rocket.UsesPerTurn = 99;
                pxLaser.UsesPerTurn = 99;
            }
        }
    }
}

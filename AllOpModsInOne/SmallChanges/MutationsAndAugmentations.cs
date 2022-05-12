using AllOpModsInOne;
using Base.Defs;
using PhoenixPoint.Tactical.Entities.Equipments;
using Base.Core;
using PhoenixPoint.Tactical.Entities.Weapons;
using System.Linq;
using Base.Entities.Abilities;

namespace AllOpModsInOne.SmallChanges
{
    internal class MutationsAndAugmentations
    {
        public static void Change_PermanentAug()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();          

            if (MyMod.Config.RemovableMutationsAndAugmentations == true)
            {
                foreach (TacticalItemDef Item in Repo.GetAllDefs<TacticalItemDef>())
                {
                    Item.IsPermanentAugment = false;
                }
            }

            if (MyMod.Config.VenomTorsoCanUseBothHands == true)
            {
                WeaponDef shooterTorso = Repo.GetAllDefs<WeaponDef>().FirstOrDefault(ged => ged.name.Equals("AN_Berserker_Shooter_LeftArm_WeaponDef"));

                shooterTorso.Abilities = new AbilityDef[]
                {
                    shooterTorso.Abilities[0],
                };
            }
           
            if (MyMod.Config.FreeBionicRepair == true)
            {
                foreach (TacticalItemDef item in Repo.GetAllDefs<TacticalItemDef>().Where(a => a.name.Contains("_BIO_")))
                {
                    item.PreserveDamageTaken = false;
                }
            }
        }
    }
}

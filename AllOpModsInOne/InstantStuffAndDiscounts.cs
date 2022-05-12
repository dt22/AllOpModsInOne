using System.Linq;
using Base.Defs;
using PhoenixPoint.Tactical.Entities.Weapons;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Common.Entities;
using Base.Core;
using PhoenixPoint.Geoscape.Entities.Research;
using PhoenixPoint.Geoscape.Entities.Interception.Equipments;
using PhoenixPoint.Common.Entities.Equipments;
using Code.PhoenixPoint.Tactical.Entities.Equipments;

namespace AllOpModsInOne
{
    internal class InstantStuffAndDiscounts
    {
        public static void Change_Time()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
            
            if (MyMod.Config.InstantManufacturing == true)
            {                
                foreach (TacticalItemDef item in Repo.GetAllDefs<TacticalItemDef>())
                {
                    item.ManufacturePointsCost = 0;
                }                    
                foreach (WeaponDef weapon in Repo.GetAllDefs<WeaponDef>())
                {
                    weapon.ManufacturePointsCost = 0;                  
               }
                foreach (GroundVehicleItemDef item in Repo.GetAllDefs<GroundVehicleItemDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
                foreach (GroundVehicleModuleDef item in Repo.GetAllDefs<GroundVehicleModuleDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
                foreach (GroundVehicleWeaponDef item in Repo.GetAllDefs<GroundVehicleWeaponDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
                foreach (VehicleItemDef item in Repo.GetAllDefs<VehicleItemDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
                foreach (GeoVehicleWeaponDef item in Repo.GetAllDefs<GeoVehicleWeaponDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
                foreach (GeoVehicleModuleDef item in Repo.GetAllDefs<GeoVehicleModuleDef>())
                {
                    item.ManufacturePointsCost = 0;
                }
            }
            
            if(MyMod.Config.InstantResearch == true)
            {
                foreach (ResearchDef rd in Repo.GetAllDefs<ResearchDef>().Where(rd => rd.name.StartsWith("PX_")))
                {
                    rd.ResearchCost = 0;
                }
            }

            if (MyMod.Config.InstantFacilityConstruction == true)
            {
                foreach (PhoenixFacilityDef facility in Repo.GetAllDefs<PhoenixFacilityDef>().Where(rd => rd.name.Contains("PhoenixFacilityDef")))
                {
                    facility.ConstructionTimeDays = 0;
                }
            }

            if (MyMod.Config.FacilitiesDoNotRequirePower == true)
            {
                foreach (PhoenixFacilityDef facility in Repo.GetAllDefs<PhoenixFacilityDef>().Where(rd => rd.name.Contains("PhoenixFacilityDef")))
                {
                    facility.PowerCost = 0;
                }
            }

            if (MyMod.Config.EverythingHalfOff == true)
            {
                foreach (PhoenixFacilityDef facility in Repo.GetAllDefs<PhoenixFacilityDef>().Where(rd => rd.name.Contains("PhoenixFacilityDef")))
                {
                    facility.ResourceCost = facility.ResourceCost/2;
                }
                foreach (TacticalItemDef item in Repo.GetAllDefs<TacticalItemDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;                 
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (WeaponDef weapon in Repo.GetAllDefs<WeaponDef>())
                {
                    weapon.ManufactureMaterials /= 2;
                    weapon.ManufactureTech /= 2;
                    weapon.ManufactureMutagen /= 2;
                    weapon.ManufactureLivingCrystals /= 2;
                    weapon.ManufactureProteanMutane /= 2;
                    weapon.ManufactureOricalcum /= 2;
                }
                foreach (GroundVehicleItemDef item in Repo.GetAllDefs<GroundVehicleItemDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (GroundVehicleModuleDef item in Repo.GetAllDefs<GroundVehicleModuleDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (GroundVehicleWeaponDef item in Repo.GetAllDefs<GroundVehicleWeaponDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (VehicleItemDef item in Repo.GetAllDefs<VehicleItemDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (GeoVehicleWeaponDef item in Repo.GetAllDefs<GeoVehicleWeaponDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }
                foreach (GeoVehicleModuleDef item in Repo.GetAllDefs<GeoVehicleModuleDef>())
                {
                    item.ManufactureMaterials /= 2;
                    item.ManufactureTech /= 2;
                    item.ManufactureMutagen /= 2;
                    item.ManufactureLivingCrystals /= 2;
                    item.ManufactureProteanMutane /= 2;
                    item.ManufactureOricalcum /= 2;
                }              
            }
        }
    }
}

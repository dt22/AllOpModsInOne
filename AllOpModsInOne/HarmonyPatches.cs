using Base;
using Base.Core;
using Base.Defs;
using Harmony;
using PhoenixPoint.Common.Core;
using PhoenixPoint.Common.Entities.GameTags;
using PhoenixPoint.Common.Entities.GameTagsSharedData;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Common.Entities.RedeemableCodes;
using PhoenixPoint.Geoscape.Entities;
using PhoenixPoint.Geoscape.Entities.Interception.Equipments;
using PhoenixPoint.Geoscape.Levels;
using PhoenixPoint.Geoscape.Levels.Factions;
using PhoenixPoint.Geoscape.View.ViewModules;
using PhoenixPoint.Tactical.Entities.Equipments;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AllOpModsInOne
{
    internal class HarmonyPatches
    {
        public static void Change_Patches()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
        }
    }
    
    [HarmonyPatch(typeof(PhoenixStatisticsManager), "OnGeoscapeLevelStart")]
    internal static class PhoenixStatisticsManager_OnGeoscapeLevelStart2
    {
        // Token: 0x06000005 RID: 5 RVA: 0x0000207C File Offset: 0x0000027C
        private static void Postfix()
        {
            if (MyMod.Config.UnlockAllBionics == true)
            {
                UnlockBionics();
            }
            if (MyMod.Config.UnlockAllMutations == true)
            {
                UnlockMutations();
            }
			if (MyMod.Config.MaxLevelSoldiers == true)
            {
                MaxLvLSoldiers();
            }
			if (MyMod.Config.GetNineThousandPlusSP == true)
            {
                InfiniteSp();
            }
			if (MyMod.Config.ManufactureEverything == true)
            {
                ManufactureAll();
            }
        }

        private static void ManufactureAll()
        {
            OptionsManager optionsManager = GameUtl.GameComponent<OptionsManager>();
            if (optionsManager != null)
            {
                GeoLevelController geoLevelController = GameUtl.CurrentLevel().GetComponent<GeoLevelController>();
                if (geoLevelController != null)
                {
                    GeoPhoenixFaction phoenixFaction = geoLevelController.PhoenixFaction;
                    SharedGameTagsDataDef sharedGameTags = GameUtl.GameComponent<SharedData>().SharedGameTags;
                    List<TacticalItemDef> list = new List<TacticalItemDef>();
                    list.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<TacticalItemDef>()
                                  where x.Tags.Contains(geoLevelController.PhoenixFactionDef.Tag)
                                  select x);
                    list.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<TacticalItemDef>()
                                  where x.Tags.Contains(geoLevelController.SynedrionFaction.Def.Tag)
                                  select x);
                    list.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<TacticalItemDef>()
                                  where x.Tags.Contains(geoLevelController.AnuFaction.Def.Tag)
                                  select x);
                    list.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<TacticalItemDef>()
                                  where x.Tags.Contains(geoLevelController.NewJerichoFaction.Def.Tag)
                                  select x);
                    list.AddRange(optionsManager.DefsRepo.GetAllDefs<RedeemableCodeDef>().SelectMany((RedeemableCodeDef x) => x.GiftedItems));
                    GameTagDef manufacturableTag = sharedGameTags.ManufacturableTag;
                    using (List<TacticalItemDef>.Enumerator enumerator = list.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            TacticalItemDef item = enumerator.Current;
                            if (!phoenixFaction.Manufacture.ManufacturableItems.Any((ManufacturableItem x) => x.RelatedItemDef.name == item.name))
                            {
                                if (!item.Tags.Contains(manufacturableTag))
                                {
                                    item.Tags.Add(manufacturableTag);
                                }
                                ManufacturableItem item2 = new ManufacturableItem(item);
                                phoenixFaction.Manufacture.ManufacturableItems.Add(item2);
                            }
                        }
                    }
                    List<GeoVehicleEquipmentDef> list2 = new List<GeoVehicleEquipmentDef>();
                    list2.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GeoVehicleEquipmentDef>()
                                   where x.Tags.Contains(geoLevelController.PhoenixFactionDef.Tag)
                                   select x);
                    list2.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GeoVehicleEquipmentDef>()
                                   where x.Tags.Contains(geoLevelController.SynedrionFaction.Def.Tag)
                                   select x);
                    list2.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GeoVehicleEquipmentDef>()
                                   where x.Tags.Contains(geoLevelController.AnuFaction.Def.Tag)
                                   select x);
                    list2.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GeoVehicleEquipmentDef>()
                                   where x.Tags.Contains(geoLevelController.NewJerichoFaction.Def.Tag)
                                   select x);
                    using (List<GeoVehicleEquipmentDef>.Enumerator enumerator = list2.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            GeoVehicleEquipmentDef item = enumerator.Current;
                            if (!phoenixFaction.Manufacture.ManufacturableItems.Any((ManufacturableItem x) => x.RelatedItemDef.name == item.name))
                            {
                                if (!item.Tags.Contains(manufacturableTag))
                                {
                                    item.Tags.Add(manufacturableTag);
                                }
                                ManufacturableItem item2 = new ManufacturableItem(item);
                                phoenixFaction.Manufacture.ManufacturableItems.Add(item2);
                            }
                        }
                    }
                    List<GroundVehicleItemDef> list3 = new List<GroundVehicleItemDef>();
                    list3.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GroundVehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.PhoenixFactionDef.Tag)
                                   select x);
                    list3.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GroundVehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.SynedrionFaction.Def.Tag)
                                   select x);
                    list3.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GroundVehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.AnuFaction.Def.Tag)
                                   select x);
                    list3.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<GroundVehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.NewJerichoFaction.Def.Tag)
                                   select x);
                    using (List<GroundVehicleItemDef>.Enumerator enumerator = list3.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            GroundVehicleItemDef item = enumerator.Current;
                            if (!phoenixFaction.Manufacture.ManufacturableItems.Any((ManufacturableItem x) => x.RelatedItemDef.name == item.name))
                            {
                                if (!item.Tags.Contains(manufacturableTag))
                                {
                                    item.Tags.Add(manufacturableTag);
                                }
                                ManufacturableItem item2 = new ManufacturableItem(item);
                                phoenixFaction.Manufacture.ManufacturableItems.Add(item2);
                            }
                        }
                    }
                    List<VehicleItemDef> list4 = new List<VehicleItemDef>();
                    list4.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<VehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.PhoenixFactionDef.Tag)
                                   select x);
                    list4.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<VehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.SynedrionFaction.Def.Tag)
                                   select x);
                    list4.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<VehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.AnuFaction.Def.Tag)
                                   select x);
                    list4.AddRange(from x in optionsManager.DefsRepo.GetAllDefs<VehicleItemDef>()
                                   where x.Tags.Contains(geoLevelController.NewJerichoFaction.Def.Tag)
                                   select x);
                    using (List<VehicleItemDef>.Enumerator enumerator = list4.GetEnumerator())
                    {
                        while (enumerator.MoveNext())
                        {
                            VehicleItemDef item = enumerator.Current;
                            if (!phoenixFaction.Manufacture.ManufacturableItems.Any((ManufacturableItem x) => x.RelatedItemDef.name == item.name))
                            {
                                if (!item.Tags.Contains(manufacturableTag))
                                {
                                    item.Tags.Add(manufacturableTag);
                                }
                                ManufacturableItem item2 = new ManufacturableItem(item);
                                phoenixFaction.Manufacture.ManufacturableItems.Add(item2);
                            }
                        }
                    }
                }
            }
        }

        private static void InfiniteSp()
        {
            OptionsManager optionsManager = GameUtl.GameComponent<OptionsManager>();
            if (optionsManager != null)
            {
                GeoLevelController geoLevelController = GameUtl.CurrentLevel().GetComponent<GeoLevelController>();
                if (geoLevelController != null)
                {
                    int skillPoints = 9999;
                    GeoLevelController._ConsoleGetLevelController().PhoenixFaction.Skillpoints += skillPoints;
                }
            }
        }

        private static void MaxLvLSoldiers()
        {
            OptionsManager optionsManager = GameUtl.GameComponent<OptionsManager>();
            if (optionsManager != null)
            {
                GeoLevelController geoLevelController = GameUtl.CurrentLevel().GetComponent<GeoLevelController>();
                if (geoLevelController != null)
                {
                    int exp = 9999;
                    (from p in GeoLevelController._ConsoleGetLevelController().ViewerFaction.Characters
                     where p.Progression != null
                     select p).ForEach(delegate (GeoCharacter c)
                     {
                         c.Progression.LevelProgression.AddExperience(exp);
                     });
                }
            }
        }

        private static void UnlockBionics()
        {
            OptionsManager optionsManager = GameUtl.GameComponent<OptionsManager>();
            if (optionsManager != null)
            {
                GeoLevelController geoLevelController = GameUtl.CurrentLevel().GetComponent<GeoLevelController>();
                if (geoLevelController != null)
                {
                    GameTagDef bionicsTag = GameUtl.GameComponent<SharedData>().SharedGameTags.BionicalTag;
                    List<ItemDef> enumerable = (from p in GameUtl.GameComponent<DefRepository>().GetAllDefs<ItemDef>()
                                                where p.Tags.Contains(bionicsTag) && p.ViewElementDef != null
                                                select p).ToList<ItemDef>();
                    GeoLevelController._ConsoleGetLevelController().ViewerFaction.UnlockedAugmentations.AddRange(enumerable);
                }
            }
        }

        private static void UnlockMutations()
        {
            OptionsManager optionsManager = GameUtl.GameComponent<OptionsManager>();
            if (optionsManager != null)
            {
                GeoLevelController geoLevelController = GameUtl.CurrentLevel().GetComponent<GeoLevelController>();
                if (geoLevelController != null)
                {
                    GameTagDef mutationTag = GameUtl.GameComponent<SharedData>().SharedGameTags.AnuMutationTag;
                    List<ItemDef> enumerable = (from p in GameUtl.GameComponent<DefRepository>().GetAllDefs<ItemDef>()
                                                where p.Tags.Contains(mutationTag) && p.ViewElementDef != null
                                                select p).ToList<ItemDef>();
                    GeoLevelController._ConsoleGetLevelController().ViewerFaction.UnlockedAugmentations.AddRange(enumerable);
                }
            }
        }
    }   		
}
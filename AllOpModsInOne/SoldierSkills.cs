using Base.Core;
using Base.Defs;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Tactical.Entities.Abilities;
using System.Linq;

namespace AllOpModsInOne
{
    internal class SoldierSkills
    {
        public static void Skills()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();

            if (MyMod.Config.OpSoldierSkills == true)
            {
                SpecializationDef assault = Repo.GetAllDefs<SpecializationDef>().FirstOrDefault(a => a.name.Equals("AssaultSpecializationDef"));
                assault.AbilityTrack.AbilitiesByLevel[5].Ability = Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("Rally_AbilityDef"));

                SpecializationDef sniper = Repo.GetAllDefs<SpecializationDef>().FirstOrDefault(a => a.name.Equals("SniperSpecializationDef"));
                sniper.AbilityTrack.AbilitiesByLevel[2].Ability = Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault((TacticalAbilityDef a) => a.name.Equals("Gunslinger_AbilityDef"));

                SpecializationDef heavy = Repo.GetAllDefs<SpecializationDef>().FirstOrDefault(a => a.name.Equals("HeavySpecializationDef"));
                heavy.AbilityTrack.AbilitiesByLevel[6].Ability = Repo.GetAllDefs<TacticalAbilityDef>().FirstOrDefault(a => a.name.Equals("RageBurst_ShootAbilityDef"));
            }
        }      
    }
}
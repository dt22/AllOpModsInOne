using System;
using Harmony;
using System.Linq;
using System.Collections.Generic;
using Base.Defs;
using PhoenixPoint.Tactical.Entities;
using PhoenixPoint.Tactical.Entities.Weapons;
using PhoenixPoint.Tactical.Entities.Equipments;
using PhoenixPoint.Tactical.Entities.Abilities;
using PhoenixPoint.Common.Entities.Items;
using PhoenixPoint.Common.Entities.Characters;
using PhoenixPoint.Common.Entities;
using PhoenixPoint.Common.Core;
using Base.Core;
using Base.Entities.Abilities;
using PhoenixPoint.Geoscape.Levels;
using Base.Entities.Effects;
using PhoenixPoint.Tactical.Levels.FactionEffects;
using PhoenixPoint.Geoscape.Events.Eventus;
using PhoenixPoint.Geoscape.Events;
using PhoenixPoint.Geoscape.Entities.Research;
using PhoenixPoint.Geoscape.Entities.Research.Reward;

namespace AllOpModsInOne
{
    internal class Corruption
    {
        public static void Change_Corruption()
        {
            DefRepository Repo = GameUtl.GameComponent<DefRepository>();
            
            if (MyMod.Config.DisableCorruption == true)
            {               
                GeoscapeEventDef geoEventCH0WIN2 = Repo.GetAllDefs<GeoscapeEventDef>().FirstOrDefault(ged => ged.name.Equals("PROG_CH2_WIN_GeoscapeEventDef"));
                GeoscapeEventDef geoEventCH0WIN = Repo.GetAllDefs<GeoscapeEventDef>().FirstOrDefault(ged => ged.name.Equals("PROG_CH0_WIN_GeoscapeEventDef"));
                
                /*
                var corruption = geoEventCH0WIN.GeoscapeEventData.Choices[0].Outcome.VariablesChange[1];
                var corruption2 = geoEventCH0WIN2.GeoscapeEventData.Choices[0].Outcome.VariablesChange[1];
                geoEventCH0WIN.GeoscapeEventData.Choices[0].Outcome.VariablesChange.Remove(corruption);
                geoEventCH0WIN2.GeoscapeEventData.Choices[0].Outcome.VariablesChange.Remove(corruption2);
                */
                
                geoEventCH0WIN.GeoscapeEventData.Choices[0].Outcome.VariablesChange = new List<OutcomeVariableChange>()
                {
                    geoEventCH0WIN.GeoscapeEventData.Choices[0].Outcome.VariablesChange[0],
                };

                geoEventCH0WIN2.GeoscapeEventData.Choices[0].Outcome.VariablesChange = new List<OutcomeVariableChange>();
            }                                          
        }
    }
}

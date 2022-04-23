using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Functions;
using HASS.Agent.Shared.Enums;
using HASS.Agent.Shared.Functions;

namespace HASS.Agent.Models.Internal
{
    public class CommandInfoCard
    {
        public CommandInfoCard()
        {
            //
        }

        public CommandInfoCard(CommandType commandType, string description, bool agentCompatible, bool satelliteCompatible, bool actionCompatible)
        {
            var (key, name) = commandType.GetLocalizedDescriptionAndKey();

            CommandType = commandType;

            Key = key;
            Name = name;
            
            Description = description;
            AgentCompatible = agentCompatible;
            SatelliteCompatible = satelliteCompatible;
            ActionCompatible = actionCompatible;
        }

        public CommandType CommandType { get; set; }

        public int Key { get; set; }
        public string Name { get; set; }
        
        public string Description { get; set; }

        public bool AgentCompatible { get; set; }
        public bool SatelliteCompatible { get; set; }
        public bool ActionCompatible { get; set; }
    }
}

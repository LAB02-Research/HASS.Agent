using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HASS.Agent.Functions;
using HASS.Agent.Shared.Enums;

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
            CommandType = commandType;
            Name = HelperFunctions.ConvertCapitalizedEntityNameToReadable(commandType.ToString());
            Description = description;
            AgentCompatible = agentCompatible;
            SatelliteCompatible = satelliteCompatible;
            ActionCompatible = actionCompatible;
        }

        public CommandType CommandType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool AgentCompatible { get; set; }
        public bool SatelliteCompatible { get; set; }
        public bool ActionCompatible { get; set; }
    }
}

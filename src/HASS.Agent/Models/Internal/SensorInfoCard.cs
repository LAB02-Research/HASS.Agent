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
    public class SensorInfoCard
    {
        public SensorInfoCard()
        {
            //
        }

        public SensorInfoCard(SensorType sensorType, string description, int refreshTimer, bool multiValue, bool agentCompatible, bool satelliteCompatible)
        {
            var (key, name) = sensorType.GetLocalizedDescriptionAndKey();

            SensorType = sensorType;

            Key = key;
            Name = name;

            Description = description;
            RefreshTimer = refreshTimer;
            MultiValue = multiValue;
            AgentCompatible = agentCompatible;
            SatelliteCompatible = satelliteCompatible;
        }

        public SensorType SensorType { get; set; }

        public int Key { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }
        public int RefreshTimer { get; set; }
        
        public bool MultiValue { get; set; }

        public bool AgentCompatible { get; set; }
        public bool SatelliteCompatible { get; set; }
    }
}

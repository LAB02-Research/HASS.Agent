using System;
using System.Text.RegularExpressions;

namespace HASSAgent.Models.Mqtt
{
    public abstract class AbstractDiscoverable
    {
        public abstract string Domain { get; }
        public string Name { get; set; }

        public string ObjectId => Regex.Replace(this.Name, "[^a-zA-Z0-9_-]", "_");
        public Guid Id { get; set; }

        public abstract DiscoveryConfigModel GetAutoDiscoveryConfig();
    }
}

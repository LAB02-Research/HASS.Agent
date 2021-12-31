using System.Text.RegularExpressions;

namespace HASSAgent.Models.HomeAssistant
{
    public abstract class AbstractDiscoverable
    {
        public abstract string Domain { get; }
        public string Name { get; set; }
        public string TopicName { get; set; }

        private string _objectId;
        public string ObjectId
        {
            get
            {
                if (!string.IsNullOrEmpty(_objectId)) return _objectId;

                _objectId = Regex.Replace(this.Name, "[^a-zA-Z0-9_-]", "_");
                return _objectId;
            }

            set => _objectId = Regex.Replace(value, "[^a-zA-Z0-9_-]", "_");
        }


        public string Id { get; set; }

        public abstract DiscoveryConfigModel GetAutoDiscoveryConfig();
    }
}

using HASSAgent.Enums;

namespace HASSAgent.Models
{
    internal class ComponentStatusUpdate
    {
        internal ComponentStatusUpdate()
        {
            //
        }

        internal ComponentStatusUpdate(Component component, ComponentStatus status)
        {
            Component = component;
            Status = status;
        }

        internal Component Component { get; set; }
        internal ComponentStatus Status { get; set; }
    }
}

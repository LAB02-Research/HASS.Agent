namespace HASSAgent.Models.HomeAssistant.Commands.CustomCommands
{
    internal class HibernateCommand : CustomCommand
    {
        internal HibernateCommand(string name = "Hibernate", string id = default) : base("shutdown /h", false, name ?? "Hibernate", id)
        {
            State = "OFF";
        }
    }
}

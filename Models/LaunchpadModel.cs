namespace GroundControl.Models
{
    public class LaunchpadModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }

        public LaunchpadModel(string id, string name, string status)
        {
            Id = id;
            Name = name;
            Status = status;
        }
    }
}

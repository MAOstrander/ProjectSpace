using System;
using System.Collections.Generic;

namespace GroundControl.Models
{
    public class SpaceXApiReturnModel // Based off of API V2
    {
        public int Padid { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Full_name { get; set; }
        public string Status { get; set; }
        public LocationModel Location { get; set; }
        public List<string> Vehicles_launched { get; set; }
        public int Attempted_launches { get; set; }
        public int Successful_launches { get; set; }
        public string wikipedia { get; set; }
        public string details { get; set; }

    }

    public class LocationModel
    {
        public string name { get; set; }
        public string region { get; set; }
        public long latitude { get; set; }
        public long longitude { get; set; }

    }
}

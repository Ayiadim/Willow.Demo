using System.Collections.Generic;

namespace Willow.Demo.Service.Entities
{
    public class Floor
    {
        public int FloorNumber { get; set; }

        public int TotalJobs { get; set;}

        public ICollection<JobGrouping> Jobs { get; set; }

        public string FloorName => $"Floor {FloorNumber}";
    }

    public class JobGrouping
    {
        public string JobStatus { get; set; }

        public string RoomType { get; set; }

        public int JobCount { get; set; }
    }
}

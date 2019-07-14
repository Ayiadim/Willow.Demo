namespace Willow.Demo.Service.Entities
{
    using System;

    public class Job
    {
        public Guid Id { get; set; }
        public int? ContractorId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public int? Floor { get; set; }
        public int? Room { get; set; }
        public string DelayReason { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateCompleted { get; set; }
        public DateTime? DateDelayed { get; set; }
        public int? StatusNum { get; set; }
        public int? RjobId { get; set; }

        public virtual RoomType RoomType { get; set; }
    }
}

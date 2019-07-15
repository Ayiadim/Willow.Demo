namespace Willow.Demo.Unit.Data
{
    using Service.Entities;
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FloorTestData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>
        {
            new object[] {
                new List<Job>
                {
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 1,
                        Name = "Renovate",
                        Status = "In Progress",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Meeting Room"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 3,
                        Name = "Build",
                        Status = "Delayed",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Meeting Room"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 2,
                        Name = "Build",
                        Status = "In Progress",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Kitchen"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 1,
                        Name = "Renovate",
                        Status = "Delayed",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Office"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 1,
                        Name = "Refurbish",
                        Status = "Delayed",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Office"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 2,
                        Name = "Paint",
                        Status = "Complete",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Main Area"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 1,
                        Name = "Paint",
                        Status = "In Progress",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Main Area"
                        }
                    },
                    new Job
                    {
                        Id = Guid.NewGuid(),
                        Floor = 1,
                        Name = "Paint",
                        Status = "In Progress",
                        RoomType = new RoomType
                        {
                            Id = Guid.NewGuid(),
                            Name = "Main Area"
                        }
                    }
                },
                new List<Floor>
                {
                    new Floor
                    {
                        FloorNumber = 1,
                        Jobs = new List<JobGrouping>
                        {
                            new JobGrouping {
                                JobCount = 2,
                                JobStatus = "In Progress",
                                RoomType = "Main Area",
                            },
                            new JobGrouping {
                                JobCount = 2,
                                JobStatus = "Delayed",
                                RoomType = "Office",
                            },
                            new JobGrouping {
                                JobCount = 1,
                                JobStatus = "In Progress",
                                RoomType = "Meeting Room",
                            },
                        },
                        TotalJobs = 5
                    },
                    new Floor
                    {
                        FloorNumber = 2,
                        Jobs = new List<JobGrouping>
                        {
                            new JobGrouping {
                                JobCount = 1,
                                JobStatus = "In Progress",
                                RoomType = "Kitchen",
                            },
                            new JobGrouping {
                                JobCount = 1,
                                JobStatus = "Complete",
                                RoomType = "Main Area",
                            }
                        },
                        TotalJobs = 2
                    },
                    new Floor
                    {
                        FloorNumber = 3,
                        Jobs = new List<JobGrouping>
                        {
                            new JobGrouping {
                                JobCount = 1,
                                JobStatus = "Delayed",
                                RoomType = "Meeting Room",
                            }
                        },
                        TotalJobs = 1
                    },
                }
            },
        };

        public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}

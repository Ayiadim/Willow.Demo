namespace Willow.Demo.Service.Services
{
    using Entities;
    using Responses;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public interface IFloorService
    {
        Task<GetFloorsQueryResponse> GetAllAsync(); 
    }

    public class FloorService : IFloorService
    {
        private readonly IJobService _jobService;

        public FloorService(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<GetFloorsQueryResponse> GetAllAsync()
        {
            var floors = new List<Floor>();

            var jobs = await _jobService.GetAllAsync();

            var floorGroups = jobs.Items
                .OrderBy(job => job.Floor)
                .GroupBy(job => job.Floor);

            foreach (var floorGroup in floorGroups)
            {
                var floor = new Floor
                {
                    FloorNumber = floorGroup.Key.Value,
                    TotalJobs = floorGroup.Count(),
                    Jobs = new List<JobGrouping>()
                };

                var jobGroups = floorGroup
                    .GroupBy(job => new { job.Status, job.RoomType.Name });

                foreach (var jobGroup in jobGroups)
                {
                    floor.Jobs.Add(new JobGrouping
                    {
                        JobCount = jobGroup.Count(),
                        JobStatus = jobGroup.Key.Status,
                        RoomType = jobGroup.Key.Name
                    });
                }

                floors.Add(floor);
            }

            return new GetFloorsQueryResponse
            {
                Success = true,
                Items = floors
            };
        }
    }
}

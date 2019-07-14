namespace Willow.Demo.Unit.Services
{
    using FluentAssertions;
    using Moq;
    using Service.Entities;
    using Service.Responses;
    using Service.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Xunit;

    public class FloorServiceTests
    {
        private readonly FloorService _floorService;
        private readonly Mock<IJobService> _jobService;

        public FloorServiceTests()
        {
            _jobService = new Mock<IJobService>();

            _jobService.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new GetJobsQueryResponse
                {
                    Items = new List<Job>
                    {
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        },
                        new Job
                        {

                        }
                    }
                })
                .Verifiable();

            _floorService = new FloorService(_jobService.Object);
        }


        [Fact]
        public async Task GetAll_WhenSomething_ReturnsResult()
        {
            var result = await _floorService.GetAllAsync();

            result.Should().BeOfType<GetFloorsQueryResponse>();

            Assert.True(result.Success);
            Assert.Equal(2, result.Items.Count);
        }
    }
}

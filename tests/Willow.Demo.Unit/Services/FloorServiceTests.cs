namespace Willow.Demo.Unit.Services
{
    using Data;
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
        [Theory]
        [ClassData(typeof(FloorTestData))]
        public async Task GetAll_WhenGivenData_ReturnsExpected(ICollection<Job> jobs, ICollection<Floor> expected)
        {
            var jobServiceMock = new Mock<IJobService>();

            jobServiceMock.Setup(s => s.GetAllAsync())
                .ReturnsAsync(new GetJobsQueryResponse
                {
                    Items = jobs
                })
                .Verifiable();

            var floorService = new FloorService(jobServiceMock.Object);

            var result = await floorService.GetAllAsync();

            result.Should().BeOfType<GetFloorsQueryResponse>();
            result.Items.Should().BeEquivalentTo(expected);
        }
    }
}

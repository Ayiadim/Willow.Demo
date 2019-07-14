namespace Willow.Demo.Api.Operations.Job.Queries
{
    using MediatR;
    using Service.Responses;
    using Service.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetJobsQueryHandler : IRequestHandler<GetJobsQuery, GetJobsQueryResponse>
    {
        private readonly IJobService _jobService;

        public GetJobsQueryHandler(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<GetJobsQueryResponse> Handle(GetJobsQuery query, CancellationToken cancellationToken)
        {
            if (query.Id.HasValue)
            {
                return await _jobService.GetAsync(query.Id.Value);
            }

            return await _jobService.GetAllAsync();
        }
    }
}

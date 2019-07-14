namespace Willow.Demo.Api.Operations.Job.Commands
{
    using MediatR;
    using Service.Responses;
    using Service.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class UpdateJobStatusCommandHandler : IRequestHandler<UpdateJobStatusCommand, UpdateJobStatusCommandResponse>
    {
        private readonly IJobService _jobService;

        public UpdateJobStatusCommandHandler(IJobService jobService)
        {
            _jobService = jobService;
        }

        public async Task<UpdateJobStatusCommandResponse> Handle(UpdateJobStatusCommand query, CancellationToken cancellationToken)
        {
            return await _jobService.UpdateStatusAsync(query.Job);
        }
    }
}

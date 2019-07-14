namespace Willow.Demo.Api.Operations.Job.Commands
{
    using MediatR;
    using Service.Entities;
    using Service.Responses;

    public class UpdateJobStatusCommand : IRequest<UpdateJobStatusCommandResponse>
    {
        public Job Job { get; set; }
    }
}

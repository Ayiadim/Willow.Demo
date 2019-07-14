namespace Willow.Demo.Api.Operations.Job.Queries
{
    using MediatR;
    using Service.Responses;
    using System;

    public class GetJobsQuery : IRequest<GetJobsQueryResponse>
    {
        public Guid? Id { get; set; }
    }
}

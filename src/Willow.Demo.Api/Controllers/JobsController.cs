namespace Willow.Demo.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Operations.Job.Commands;
    using Operations.Job.Queries;
    using Service.Responses;
    using System;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public JobsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetJobsQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GetJobsQueryResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetJobsQuery();

            var result = await _mediator.Send(query);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetJobsQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GetJobsQueryResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Get(Guid id)
        {
            var query = new GetJobsQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut]
        [Route("status")]
        [ProducesResponseType(typeof(UpdateJobStatusCommandResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(UpdateJobStatusCommandResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> UpdateJobStatus(UpdateJobStatusCommand command)
        {
            var result = await _mediator.Send(command);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

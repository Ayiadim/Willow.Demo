namespace Willow.Demo.Api.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Operations.Floor.Queries;
    using Service.Responses;
    using System.Net;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class FloorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FloorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetFloorsQueryResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(GetFloorsQueryResponse), (int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> GetFloor()
        {
            var query = new GetFloorsQuery();

            var result = await _mediator.Send(query);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}

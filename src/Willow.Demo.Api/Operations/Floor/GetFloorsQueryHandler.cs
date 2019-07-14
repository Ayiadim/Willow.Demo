namespace Willow.Demo.Api.Operations.Floor.Queries
{
    using MediatR;
    using Service.Responses;
    using Service.Services;
    using System.Threading;
    using System.Threading.Tasks;

    public class GetFloorsQueryHandler : IRequestHandler<GetFloorsQuery, GetFloorsQueryResponse>
    {
        private readonly IFloorService _floorService;

        public GetFloorsQueryHandler(IFloorService floorService)
        {
            _floorService = floorService;
        }

        public async Task<GetFloorsQueryResponse> Handle(GetFloorsQuery query, CancellationToken cancellationToken)
        {
            return await _floorService.GetAllAsync();
        }
    }
}

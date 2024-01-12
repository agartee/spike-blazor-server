using MediatR;
using Spike.Domain.Models;

namespace Spike.Domain.Queries
{
    public record DemandSimulator : IRequest<SimulatorInfo>
    {
        public required SimulatorId Id { get; init; }
    }

    public class DemandSimulatorHandler : IRequestHandler<DemandSimulator, SimulatorInfo>
    {
        public Task<SimulatorInfo> Handle(DemandSimulator request, CancellationToken cancellationToken)
        {
            return Task.FromResult(new SimulatorInfo { Id = request.Id, Name = "Some Simulator" });
        }
    }
}

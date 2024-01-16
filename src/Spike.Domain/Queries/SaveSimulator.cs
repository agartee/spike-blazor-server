using MediatR;
using Spike.Domain.Models;

namespace Spike.Domain.Queries
{
    public record SaveSimulator : IRequest<SimulatorInfo>
    {
        public required SimulatorId Id { get; init; }
        public required string Name { get; init; }
    }

    public class SaveSimulatorHandler : IRequestHandler<SaveSimulator, SimulatorInfo>
    {
        public Task<SimulatorInfo> Handle(SaveSimulator request, CancellationToken cancellationToken)
        {
            Thread.Sleep(2000);

            return Task.FromResult(new SimulatorInfo { Id = request.Id, Name = request.Name });
        }
    }
}

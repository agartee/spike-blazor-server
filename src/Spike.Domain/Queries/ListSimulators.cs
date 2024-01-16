using MediatR;
using Spike.Domain.Models;

namespace Spike.Domain.Queries
{
    public record ListSimulators : IRequest<IEnumerable<SimulatorInfo>>
    {
    }

    public class ListSimulatorsHandler : IRequestHandler<ListSimulators, IEnumerable<SimulatorInfo>>
    {
        public async Task<IEnumerable<SimulatorInfo>> Handle(ListSimulators request, CancellationToken cancellationToken)
        {
            await Task.Delay(2000);

            return new[]
            {
                new SimulatorInfo { Id = new SimulatorId(1), Name = "Simulator Alpha" },
                new SimulatorInfo { Id = new SimulatorId(2), Name = "Simulator Bravo" },
                new SimulatorInfo { Id = new SimulatorId(3), Name = "Simulator Charlie" },
                new SimulatorInfo { Id = new SimulatorId(4), Name = "Simulator Delta" },
            };
        }
    }
}

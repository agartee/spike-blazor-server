namespace Spike.Domain.Models
{
    public record SimulatorInfo
    {
        public required SimulatorId Id { get; init; }
        public required string Name { get; init; }
    }
}

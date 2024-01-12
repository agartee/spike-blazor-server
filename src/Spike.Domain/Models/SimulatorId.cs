namespace Spike.Domain.Models
{
    public record SimulatorId
    {
        public SimulatorId(int value)
        {
            Value = value;
        }

        public int Value { get; private set; }

        public override string ToString()
        {
            return $"{Value}";
        }
    }
}

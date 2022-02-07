namespace Catalog.Host.Data.Entities
{
    public class SpecificationDto
    {
        public int Id { get; set; }
        public string Socket { get; set; } = null!;
        public int NumberOfCores { get; set; }
        public int NumberOfThreads { get; set; }
        public double ClockFrequency { get; set; }
        public double MaximumClockFrequency { get; set; }
        public string MemoryType { get; set; } = null!;
        public string VideoLink { get; set; } = null!;
    }
}

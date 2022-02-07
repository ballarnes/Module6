namespace Catalog.Host.Repositories.Interfaces
{
    public interface ISpecificationRepository
    {
        Task<int?> AddSpecificationAsync(string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink);
        Task<string?> RemoveSpecificationAsync(int id);
        Task<string?> UpdateSpecificationAsync(int id, string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink);
    }
}

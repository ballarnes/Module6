using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class SpecificationRepositiry : ISpecificationRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<SpecificationRepositiry> _logger;

    public SpecificationRepositiry(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<SpecificationRepositiry> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddSpecificationAsync(string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink)
    {
        var newSpec = await _dbContext.Specifications.AddAsync(new Specification
        {
            Socket = socket,
            NumberOfCores = numberOfCores,
            NumberOfThreads = numberOfThreads,
            ClockFrequency = clockFrequency,
            MaximumClockFrequency = maximumClockFrequency,
            MemoryType = memoryType,
            VideoLink = videoLink!
        });

        await _dbContext.SaveChangesAsync();

        return newSpec.Entity.Id;
    }

    public async Task<string?> RemoveSpecificationAsync(int id)
    {
        var spec = await _dbContext.Specifications.Where(c => c.Id == id).FirstOrDefaultAsync();
        _dbContext.Specifications.Remove(spec!);

        await _dbContext.SaveChangesAsync();

        return $"Successfully deleted. ({DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss")})";
    }

    public async Task<string?> UpdateSpecificationAsync(int id, string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink)
    {
        var specFromDb = await _dbContext.Specifications.Where(i => i.Id == id).FirstOrDefaultAsync();
        specFromDb!.Socket = socket;
        specFromDb.NumberOfCores = numberOfCores;
        specFromDb.NumberOfThreads = numberOfThreads;
        specFromDb.ClockFrequency = clockFrequency;
        specFromDb.MaximumClockFrequency = maximumClockFrequency;
        specFromDb.MemoryType = memoryType;
        specFromDb.VideoLink = videoLink!;

        _dbContext.Specifications.Update(specFromDb);

        await _dbContext.SaveChangesAsync();

        return $"Successfully updated. ({DateTime.UtcNow.ToString("dddd, dd MMMM yyyy HH:mm:ss")})";
    }
}
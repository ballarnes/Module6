using Catalog.Host.Data;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services;

public class CatalogService : BaseDataService<ApplicationDbContext>, ICatalogService
{
    private readonly ICatalogItemRepository _catalogItemRepository;
    private readonly ICatalogBrandRepository _catalogBrandRepository;
    private readonly ISpecificationRepository _specificationRepository;
    private readonly IMapper _mapper;

    public CatalogService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ICatalogItemRepository catalogItemRepository,
        ICatalogBrandRepository catalogBrandRepository,
        ISpecificationRepository specificationRepository,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _catalogItemRepository = catalogItemRepository;
        _catalogBrandRepository = catalogBrandRepository;
        _specificationRepository = specificationRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedItemsResponse<CatalogItemDto>?> GetByPageAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters)
    {
        return await ExecuteSafeAsync(async () =>
        {
            int? brandFilter = null;

            if (filters != null)
            {
                if (filters.TryGetValue(CatalogTypeFilter.Brand, out var brand))
                {
                    brandFilter = brand;
                }
            }

            var result = await _catalogItemRepository.GetByPageAsync(pageIndex, pageSize, brandFilter);
            if (result == null)
            {
                return null;
            }

            return new PaginatedItemsResponse<CatalogItemDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogItemDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public async Task<CatalogItemDto> GetByIdAsync(int id)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetByIdAsync(id);
            var mapped = _mapper.Map<CatalogItemDto>(result);
            return mapped;
        });
    }

    public async Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsAsync(int pageSize, int pageIndex)
    {
        return await ExecuteSafeAsync(async () =>
        {
            var result = await _catalogItemRepository.GetBrandsAsync(pageIndex, pageSize);
            return new PaginatedItemsResponse<CatalogBrandDto>()
            {
                Count = result.TotalCount,
                Data = result.Data.Select(s => _mapper.Map<CatalogBrandDto>(s)).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize
            };
        });
    }

    public Task<int?> AddItemAsync(string name, int catalogBrandId, decimal price, int specificationId, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.AddItemAsync(name, catalogBrandId, price, specificationId, pictureFileName));
    }

    public Task<string?> RemoveItemAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.RemoveItemAsync(id));
    }

    public Task<string?> UpdateItemAsync(int id, string name, int catalogBrandId, decimal price, int specificationId, string pictureFileName)
    {
        return ExecuteSafeAsync(() => _catalogItemRepository.UpdateItemAsync(id, name, catalogBrandId, price, specificationId, pictureFileName));
    }

    public Task<int?> AddBrandAsync(string brand)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.AddBrandAsync(brand));
    }

    public Task<string?> RemoveBrandAsync(int id)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.RemoveBrandAsync(id));
    }

    public Task<string?> UpdateBrandAsync(int id, string brand)
    {
        return ExecuteSafeAsync(() => _catalogBrandRepository.UpdateBrandAsync(id, brand));
    }

    public Task<int?> AddSpecificationAsync(string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink)
    {
        return ExecuteSafeAsync(() => _specificationRepository.AddSpecificationAsync(socket, numberOfCores, numberOfThreads, clockFrequency, maximumClockFrequency, memoryType, videoLink));
    }

    public Task<string?> RemoveSpecificationAsync(int id)
    {
        return ExecuteSafeAsync(() => _specificationRepository.RemoveSpecificationAsync(id));
    }

    public Task<string?> UpdateSpecificationAsync(int id, string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink)
    {
        return ExecuteSafeAsync(() => _specificationRepository.UpdateSpecificationAsync(id, socket, numberOfCores, numberOfThreads, clockFrequency, maximumClockFrequency, memoryType, videoLink));
    }
}
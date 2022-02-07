using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Enums;
using Catalog.Host.Models.Response;

namespace Catalog.Host.Services.Interfaces;

public interface ICatalogService
{
    Task<PaginatedItemsResponse<CatalogItemDto>?> GetByPageAsync(int pageSize, int pageIndex, Dictionary<CatalogTypeFilter, int>? filters);
    Task<CatalogItemDto> GetByIdAsync(int id);
    Task<PaginatedItemsResponse<CatalogBrandDto>> GetBrandsAsync(int pageSize, int pageIndex);
    Task<int?> AddItemAsync(string name, int catalogBrandId, decimal price, int specificationId, string pictureFileName);
    Task<string?> RemoveItemAsync(int id);
    Task<string?> UpdateItemAsync(int id, string name, int catalogBrandId, decimal price, int specificationId, string pictureFileName);
    Task<int?> AddBrandAsync(string brand);
    Task<string?> RemoveBrandAsync(int id);
    Task<string?> UpdateBrandAsync(int id, string brand);
    Task<int?> AddSpecificationAsync(string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink);
    Task<string?> RemoveSpecificationAsync(int id);
    Task<string?> UpdateSpecificationAsync(int id, string socket, int numberOfCores, int numberOfThreads, double clockFrequency, double maximumClockFrequency, string memoryType, string? videoLink);
}
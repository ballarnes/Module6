using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public static class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.CatalogBrands.Any())
        {
            await context.CatalogBrands.AddRangeAsync(GetPreconfiguredCatalogBrands());

            await context.SaveChangesAsync();
        }

        if (!context.Specifications.Any())
        {
            await context.Specifications.AddRangeAsync(GetPreconfiguredSpecifications());

            await context.SaveChangesAsync();
        }

        if (!context.CatalogItems.Any())
        {
            await context.CatalogItems.AddRangeAsync(GetPreconfiguredItems());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<CatalogBrand> GetPreconfiguredCatalogBrands()
    {
        return new List<CatalogBrand>()
        {
            new CatalogBrand() { Brand = "AMD" },
            new CatalogBrand() { Brand = "Intel" }
        };
    }

    private static IEnumerable<Specification> GetPreconfiguredSpecifications()
    {
        return new List<Specification>()
        {
            new Specification() { Socket = "AM4", NumberOfCores = 6, NumberOfThreads = 12, ClockFrequency = 3.7, MaximumClockFrequency = 4.7, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/zN0B-awvA-Y" },
            new Specification() { Socket = "1200", NumberOfCores = 6, NumberOfThreads = 12, ClockFrequency = 2.6, MaximumClockFrequency = 4.4, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/TxXrBTEDLmg" },
            new Specification() { Socket = "AM4", NumberOfCores = 8, NumberOfThreads = 16, ClockFrequency = 3.8, MaximumClockFrequency = 4.7, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/tUe5B2zjEPU" },
            new Specification() { Socket = "1200", NumberOfCores = 6, NumberOfThreads = 12, ClockFrequency = 2.9, MaximumClockFrequency = 4.3, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/goC43msTkbY" },
            new Specification() { Socket = "AM4", NumberOfCores = 4, NumberOfThreads = 4, ClockFrequency = 3.1, MaximumClockFrequency = 3.4, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/bO2hXLaVC-0" },
            new Specification() { Socket = "1200", NumberOfCores = 4, NumberOfThreads = 8, ClockFrequency = 3.7, MaximumClockFrequency = 4.4, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/Bd352lZmHRQ" },
            new Specification() { Socket = "AM4", NumberOfCores = 6, NumberOfThreads = 12, ClockFrequency = 3.2, MaximumClockFrequency = 3.6, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/69X5fWL1JRY" },
            new Specification() { Socket = "1200", NumberOfCores = 2, NumberOfThreads = 4, ClockFrequency = 4.0, MaximumClockFrequency = 4.0, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/S5FvQpaZFGE" },
            new Specification() { Socket = "sTR4", NumberOfCores = 8, NumberOfThreads = 16, ClockFrequency = 3.8, MaximumClockFrequency = 4.0, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/StPk_3a99hA" },
            new Specification() { Socket = "1200", NumberOfCores = 12, NumberOfThreads = 20, ClockFrequency = 3.6, MaximumClockFrequency = 5.0, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/2sNCml1HCxU" },
            new Specification() { Socket = "AM4", NumberOfCores = 8, NumberOfThreads = 16, ClockFrequency = 3.9, MaximumClockFrequency = 4.5, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/FXIu-LxPuuQ" },
            new Specification() { Socket = "2011-3", NumberOfCores = 8, NumberOfThreads = 16, ClockFrequency = 2.1, MaximumClockFrequency = 3.0, MemoryType = "DDR4", VideoLink = "https://www.youtube.com/embed/NNbh7uBCOWU" }
        };
    }

    private static IEnumerable<CatalogItem> GetPreconfiguredItems()
    {
        return new List<CatalogItem>()
        {
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 1, Name = "Ryzen 5 5600X", Price = 9399, PictureFileName = "1.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 2, Name = "Core i5-11400F", Price = 5299, PictureFileName = "2.png" },
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 3, Name = "Ryzen 7 5800X", Price = 12626, PictureFileName = "3.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 4, Name = "Core i5-10400", Price = 4999, PictureFileName = "4.png" },
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 5, Name = "Ryzen 3 1200", Price = 3099, PictureFileName = "5.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 6, Name = "Core i3-10300", Price = 5100, PictureFileName = "6.png" },
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 7, Name = "Ryzen 5 1600", Price = 5059, PictureFileName = "7.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 8, Name = "Pentium G6400", Price = 3626, PictureFileName = "8.png" },
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 9, Name = "Ryzen Threadripper 1900X", Price = 2967, PictureFileName = "9.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 10, Name = "Core i7-12700K", Price = 14330, PictureFileName = "10.png" },
            new CatalogItem { CatalogBrandId = 1, SpecificationId = 11, Name = "Ryzen 7 3800X", Price = 9529, PictureFileName = "11.png" },
            new CatalogItem { CatalogBrandId = 2, SpecificationId = 12, Name = "Xeon E5-2620 v4", Price = 14995, PictureFileName = "12.png" }
        };
    }
}
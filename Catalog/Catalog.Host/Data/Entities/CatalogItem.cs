namespace Catalog.Host.Data.Entities;

public class CatalogItem
{
    public int Id { get; set; }
    public int CatalogBrandId { get; set; }
    public CatalogBrand CatalogBrand { get; set; } = null!;
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public int SpecificationId { get; set; }
    public Specification Specification { get; set; } = null!;
    public string PictureFileName { get; set; } = null!;
}

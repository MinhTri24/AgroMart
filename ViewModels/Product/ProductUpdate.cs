using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgroMart.ViewModels.Product;

public class ProductUpdate
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Image { get; set; }
    
    public SelectList? Categories { get; set; }
    public string? ProductCategory { get; set; }    
    
    public SelectList? Brands { get; set; }
    public string? ProductBrand { get; set; }
}
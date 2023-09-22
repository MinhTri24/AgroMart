using System.ComponentModel.DataAnnotations;

namespace AgroMart.Models;

public class Product
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string? Image { get; set; }
    public DateTime CreateAt { get; set; }
    public DateTime UpdateAt { get; set; }
    
    public Product()
    {
        CreateAt = DateTime.Now;
        UpdateAt = DateTime.Now;
    }
    
    [Required]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    
    [Required] 
    public int BrandId { get; set; }
    public Brand? Brand { get; set; }
}
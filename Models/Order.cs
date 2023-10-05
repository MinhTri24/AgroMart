namespace AgroMart.Models;

public class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreateAt { get; set; }
    
    public Order()
    {
        CreateAt = DateTime.Now;
    }
    
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public ICollection<OrderOrderedItem> OrderOrderedItems { get; set; }
}
namespace AgroMart.Models;

public class OrderOrderedItem
{
    public int OrderId { get; set; }
    public Order? Order { get; set; }
    
    public int OrderedItemId { get; set; }
    public OrderedItem? OrderedItem { get; set; }
}
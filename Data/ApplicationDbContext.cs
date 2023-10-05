using AgroMart.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AgroMart.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<OrderOrderedItem>()
            .HasKey(o => new { o.OrderId, o.OrderedItemId });
    }

    public virtual DbSet<Category> Categories { get; set; }
    public virtual DbSet<Brand> Brands { get; set; }
    public virtual DbSet<Product> Products { get; set; }
    public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderedItem> OrderedItems { get; set; }
    public virtual DbSet<OrderOrderedItem> OrderOrderedItems { get; set; }
}
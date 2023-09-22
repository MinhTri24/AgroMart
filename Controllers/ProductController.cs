using AgroMart.Data;
using AgroMart.Models;
using AgroMart.ViewModels.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AgroMart.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    public IActionResult Index()
    {
        var products = _db.Products.Include(("Category")).Include(("Brand")).ToList();
        return View(products);
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        var categories = from c in _db.Categories select c.Name;
        var brands = from b in _db.Brands select b.Name;
        
        ProductCreate productCreate = new ProductCreate()
        {
            Categories = new SelectList(categories),
            Brands = new SelectList(brands)
        };
        return View(productCreate);
    }
    
    [HttpPost]
    public IActionResult Create(ProductCreate productCreate)
    {
        Category category = _db.Categories.FirstOrDefault(c => c.Name == productCreate.ProductCategory);
        Brand brand = _db.Brands.FirstOrDefault(b => b.Name == productCreate.ProductBrand);
        
        if (ModelState.IsValid)
        {
            Product newProduct = new Product()
            {
                CategoryId = category.Id,
                BrandId = brand.Id,
                Name = productCreate.Name,
                Description = productCreate.Description,
                Price = productCreate.Price,
                Stock = productCreate.Stock,
                Image = productCreate.Image
            };
            _db.Products.Add(newProduct);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(productCreate);
    }
    
    [HttpGet]
    public IActionResult Update(int id)
    {
        var products = _db.Products.Find(id);
        var categories = from c in _db.Categories select c.Name;
        var brands = from b in _db.Brands select b.Name;
        
        if (products != null)
        {
            ProductUpdate productUpdate = new ProductUpdate()
            {
                Id = products.Id,
                Name = products.Name,
                Description = products.Description,
                Price = products.Price,
                Stock = products.Stock,
                Image = products.Image,
                Categories = new SelectList(categories),
                Brands = new SelectList(brands)
            };
            return View(productUpdate);
        }

        return RedirectToAction("Index");
    }
    
    [HttpPost]
    public IActionResult Update(ProductUpdate productUpdate)
    {
        var product = _db.Products.Find(productUpdate.Id);
        Category category = _db.Categories.FirstOrDefault(c => c.Name == productUpdate.ProductCategory);
        Brand brand = _db.Brands.FirstOrDefault(b => b.Name == productUpdate.ProductBrand);
        
        product.CategoryId = category.Id;
        product.BrandId = brand.Id;
        product.Name = productUpdate.Name;
        product.Description = productUpdate.Description;
        product.Price = productUpdate.Price;
        product.Stock = productUpdate.Stock;
        product.Image = productUpdate.Image;
        product.UpdateAt = DateTime.Now;
        _db.SaveChanges();
        return RedirectToAction("Index");
    }


    public IActionResult Delete(int id)
    {
        var products = _db.Products.Find(id);
        if (products != null)
        {
            _db.Products.Remove(products);
            _db.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}
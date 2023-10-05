using AgroMart.Data;
using AgroMart.Models;
using AgroMart.ViewModels.Brand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroMart.Controllers;

[Authorize]
[AutoValidateAntiforgeryToken]
public class BrandController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public BrandController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [AutoValidateAntiforgeryToken]
    public IActionResult Index()
    {
        var brands = _db.Brands.ToList();
        return View(brands);
    }
    
    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create()
    {
        BrandCreate brandCreate = new BrandCreate();
        return View(brandCreate);
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(BrandCreate brandCreate)
    {
        if (ModelState.IsValid)
        {
            Brand newBrand = new Brand()
            {
                Name = brandCreate.Name,
                Description = brandCreate.Description
            };
            _db.Brands.Add(newBrand);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(brandCreate);
    }
    
    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Update(int id)
    {
        var brands = _db.Brands.Find(id);
        if (brands != null)
        {
            BrandUpdate brandUpdate = new BrandUpdate()
            {
                Id = brands.Id,
                Name = brands.Name,
                Description = brands.Description
            };
            return View(brandUpdate);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Update(BrandUpdate brandUpdate)
    {
        if (ModelState.IsValid)
        {
            Brand newBrand = new Brand()
            {
                Id = brandUpdate.Id,
                Name = brandUpdate.Name,
                Description = brandUpdate.Description
            };
            _db.Brands.Update(newBrand);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }
    
    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Delete(int id)
    {
        var brands = _db.Brands.Find(id);
        if (brands != null)
        {
            _db.Brands.Remove(brands);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }
}
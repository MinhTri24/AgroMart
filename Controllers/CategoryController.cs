using AgroMart.Data;
using AgroMart.Models;
using AgroMart.ViewModels.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgroMart.Controllers;

[Authorize]
[AutoValidateAntiforgeryToken]
public class CategoryController : Controller
{
    private readonly ApplicationDbContext _db;
    
    public CategoryController(ApplicationDbContext db)
    {
        _db = db;
    }
    
    [AutoValidateAntiforgeryToken]
    public IActionResult Index()
    {
        var categories = _db.Categories.ToList();
        return View(categories);
    }
    
    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create()
    {
        CategoryCreate categoryCreate = new CategoryCreate();
        return View(categoryCreate);
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Create(CategoryCreate categoryCreate)
    {
        if (ModelState.IsValid)
        {
            Category newCategory = new Category()
            {
                Name = categoryCreate.Name,
                Description = categoryCreate.Description
            };
            _db.Categories.Add(newCategory);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(categoryCreate);
    }
    
    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Update(int id)
    {
        var categories = _db.Categories.Find(id);
        if (categories != null)
        {
            CategoryUpdate categoryUpdate = new CategoryUpdate()
            {
                Id = categories.Id,
                Name = categories.Name,
                Description = categories.Description
            };
            return View(categoryUpdate);
        }
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [AutoValidateAntiforgeryToken]
    public IActionResult Update(CategoryUpdate categoryUpdate)
    {
        if (ModelState.IsValid)
        {
            var categories = _db.Categories.Find(categoryUpdate.Id);
            if (categories != null)
            {
                categories.Name = categoryUpdate.Name;
                categories.Description = categoryUpdate.Description;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        return NotFound();
    }

    [HttpGet]
    [AutoValidateAntiforgeryToken]
    public IActionResult Delete(int id)
    {
        var category = _db.Categories.Find(id);
        if (category != null)
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        return NotFound();
    }
}
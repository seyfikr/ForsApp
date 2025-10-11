using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace FormsApp.Controllers;

public class HomeController : Controller
{
    public HomeController()
    {

    }
    public IActionResult Index(string searchString, int category = 0)
    {
        var products = Repository.Products;
        if (!String.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString;
            products = products
                .Where(p => p.Name!.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        if (category != 0)
        {
            products = products.Where(p => p.CategoryId  == category).ToList();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(products);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Product model,IFormFile imageFile)
    {
        var allowedExtension = new[] { ".jpeg" , ".jpg" ,".png" };
        var extension = Path.GetExtension(imageFile.FileName);
        var randomFileName =string.Format($"{Guid.NewGuid().ToString()}{extension}");
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Image", randomFileName);
        if(imageFile!=null)
        {
            if(!allowedExtension.Contains(extension))
            {
                ModelState.AddModelError("", "Geçerli bir resim seçiniz");
            }
        }
        if (ModelState.IsValid)
        {
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await imageFile!.CopyToAsync(stream);
            }
            model.Image = randomFileName;
            model.ProductId = Repository.Products.Count + 1;
            Repository.CreateProduct(model);
            return RedirectToAction("Index");
        }
        // ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        ViewBag.Categories = Repository.Categories;

        return View(model);
  
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = Repository.Categories;
        return View();
    }
}

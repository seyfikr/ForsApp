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
                .Where(p => p.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        if (category != 0)
        {
            products = products.Where(p => p.CatetoryId == category).ToList();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name", category);
        return View(products);
    }
    [HttpPost]
    public IActionResult Create(Product model)
    {
        ViewBag.Categories = Repository.Categories;
        if (ModelState.IsValid)
        {
            Repository.Products.Add(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }
    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = Repository.Categories;
        return View();
    }
}

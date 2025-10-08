namespace FormsApp.Models;

public class Repository
{
    private static readonly List<Product> _products = new();
    private static readonly List<Category> _categories = new();
    static Repository()
    {
        _categories.Add(new Category { Name = "Telefon", CategoryId = 1 });
        _categories.Add(new Category { Name = "Bilgisayar", CategoryId = 2 });
        _products.Add(new Product { Name = "İphone 15", Price = 60000, IsActive = true, CatetoryId = 1, Image = "iphone15.jpg", ProductId = 1 });
        _products.Add(new Product { Name = "İphone 16", Price = 70000, IsActive = true, CatetoryId = 1, Image = "iphone16.jpg", ProductId = 2 });
        _products.Add(new Product { Name = "İphone 16 Pro", Price = 80000, IsActive = false, CatetoryId = 1, Image = "iphone16pro.jpg", ProductId = 3 });
        _products.Add(new Product { Name = "Samsung s24", Price = 600000, IsActive = true, CatetoryId = 1, Image = "s24.jpg", ProductId = 4 });
        _products.Add(new Product { Name = "Xiaomi 17", Price = 50000, IsActive = true, CatetoryId = 1, Image = "xiaomi17.jpg", ProductId = 5 });
        _products.Add(new Product { Name = "Lenavo Ideaped", Price = 45000, IsActive = true, CatetoryId = 2, Image = "lenovo.jpg", ProductId = 6 });
        _products.Add(new Product { Name = "Macbook Air", Price = 55000, IsActive = true, CatetoryId = 2, Image = "macbook.jpg", ProductId = 7 });
    }
    public static List<Product> Products
    {
        get { return _products; }
    }
    public static List<Category> Categories
    {
        get { return _categories; }
    }

}

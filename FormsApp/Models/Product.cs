using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace FormsApp.Models;

public class Product
{
    [Display(Name = "Urun Id")]

    public int ProductId { get; set; }


    [Display(Name = "Urun Adı")]
    [Required]
    public string? Name { get; set; }

    [Required]
    [Range(0,100000)]
    [Display(Name = "Fiyat")]
    public Decimal? Price { get; set; }

    
    [Display(Name = "Resim")]
    public string Image { get; set; } = string.Empty;



    public bool IsActive { get; set; }

    [Display(Name = "Category")]

    public int CategoryId  { get; set; }
}

using BakeryShop_Razor.Data;
using BakeryShop_Razor.Model;
using BakeryShop_Razor.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;

namespace BakeryShop_Razor.Pages
{
    public class IndexModel : PageModel
    {
        private readonly BakeryDbContext db;
        public List<Product> products { get; set; } = new List<Product>();
        public Product FeaturedProduct { get; set; }
        public IndexModel(BakeryDbContext db)
        {
            this.db = db;
        }
        public async Task OnGetAsync()
        {
            products = await db.products.ToListAsync();

            FeaturedProduct = products[new Random().Next(0,products.Count)];
        }
    }
}
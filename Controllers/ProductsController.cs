using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSitePractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{product.Name} was added successfully!";
                return View();
            }
            return View(product);
        }
    }
}

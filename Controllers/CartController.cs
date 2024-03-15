using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSitePractice.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductContext _context;

        public CartController(ProductContext context)
        {
            _context = context;
        }

        public IActionResult Add(int id)
        {
            Product? productToAdd = _context.Products.Where(p => p.ProductID == id).SingleOrDefault();

            if (productToAdd == null)
            {
                // Product not found
                TempData["Message"] = "That item is no longer in stock";
                return RedirectToAction("Index", "Games");
            }


            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("Index", "Games");
        }
    }
}

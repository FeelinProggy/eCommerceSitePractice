using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSitePractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return View(products);
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

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? productToEdit = await _context.Products.FindAsync(id);

            if (productToEdit == null)
            {
                return RedirectToAction("Index");
            }

            return View(productToEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product productModel)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(productModel);
                await _context.SaveChangesAsync();

                TempData["Message"] = $"{productModel.Name} was updated successfully!";
                return RedirectToAction("Index");
            }
            return View(productModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            Product? productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete == null)
            {
                return RedirectToAction("Index");
            }

            return View(productToDelete);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Product? productToDelete = await _context.Products.FindAsync(id);

            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                await _context.SaveChangesAsync();
                TempData["Message"] = $"{productToDelete.Name} was deleted successfully!";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["Message"] = "This product was already deleted.";
                return RedirectToAction("Index");
            }

        }

    }
}

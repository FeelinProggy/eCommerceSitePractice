using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eCommerceSitePractice.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductContext _context;
        private readonly List<string> _categories;

        public ProductsController(ProductContext context)
        {
            _context = context;
            _categories = new List<string> { "Candy", "Baked Goods", "Merchandise" };
        }

        public async Task<IActionResult> Index(int? pageNumber, int pageSize = 6)
        {
            // Pagination
            // Set currentPageNumber to pageNumber if it has a value, else set to 1
            int currentPageNumber = pageNumber ?? 1; 
            // Calculate the number of items to skip for each previous page, offset by 1
            int skipNumber = (currentPageNumber - 1) * pageSize;

            List<Product> products = await _context.Products
                .Skip(skipNumber)
                .Take(pageSize)
                .ToListAsync();
            return View(products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_categories);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product productToAdd)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(productToAdd);
                await _context.SaveChangesAsync();

                ViewData["Message"] = $"{productToAdd.Name} was added successfully!";
                return View();
            }
            return View(productToAdd);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Product? productToEdit = await _context.Products.FindAsync(id);

            if (productToEdit == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_categories);
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

        public async Task<IActionResult> Details(int id)
        {
            Product? productDetails = await _context.Products.FindAsync(id);

            if (productDetails == null)
            {
                return RedirectToAction("Index");
            }

            return View(productDetails);
        }

    }
}

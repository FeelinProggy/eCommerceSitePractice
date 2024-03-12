using Microsoft.AspNetCore.Mvc;

namespace eCommerceSitePractice.Controllers
{
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}

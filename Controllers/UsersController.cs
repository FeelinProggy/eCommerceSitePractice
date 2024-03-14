using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;

namespace eCommerceSitePractice.Controllers
{
    public class UsersController : Controller
    {
        private readonly ProductContext _context;
        public UsersController(ProductContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel regModel)
        {
            if (ModelState.IsValid)
            {
                // Map RegisterViewModel data to User object
                User newUser = new()
                {
                    Email = regModel.Email,
                    Password = regModel.Password
                };

                // Add user to database
                _context.Users.Add(newUser);
                await _context.SaveChangesAsync();

                // Redirect to home page
                return RedirectToAction("Index", "Home");
            }
            return View(regModel);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
    }
}

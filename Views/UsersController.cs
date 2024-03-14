using Microsoft.AspNetCore.Mvc;

namespace eCommerceSitePractice.Views
{
    public class UsersController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}

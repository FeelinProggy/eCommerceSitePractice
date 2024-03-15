using eCommerceSitePractice.Data;
using eCommerceSitePractice.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eCommerceSitePractice.Controllers
{
    public class CartController : Controller
    {
        private readonly ProductContext _context;
        private const string Cart = "ShoppingCart";

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
                return RedirectToAction("Index", "Products");
            }

            CartProductViewModel cartProduct = new()
            {
                ProductID = productToAdd.ProductID,
                Name = productToAdd.Name,
                Price = productToAdd.Price
            };

            List<CartProductViewModel> cartProducts = GetExistingCartData();
            cartProducts.Add(cartProduct);
            WriteShoppingCartCookie(cartProducts);

            TempData["Message"] = "Item added to cart!";
            return RedirectToAction("Index", "Products");
        }

        private void WriteShoppingCartCookie(List<CartProductViewModel> cartProducts)
        {
            string cookieData = JsonConvert.SerializeObject(cartProducts);

            HttpContext.Response.Cookies.Append(Cart, cookieData, new CookieOptions()
            {
                Expires = DateTimeOffset.Now.AddDays(7)
            });
        }

        /// <summary>
        /// Return the current list of video games in the user's shopping cart cookie.
        /// If the cookie does not exist, return an empty list.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        private List<CartProductViewModel> GetExistingCartData()
        {
            string? cartCookie = HttpContext.Request.Cookies[Cart];

            if (string.IsNullOrEmpty(cartCookie))
            {
                return new List<CartProductViewModel>();
            }

            return JsonConvert.DeserializeObject<List<CartProductViewModel>>(cartCookie);


        }

        public IActionResult Summary()
        {
            // Read shopping cart cookie and convert to list of CartProductViewModel

            List<CartProductViewModel> cartProducts = GetExistingCartData();
            return View(cartProducts);
        }

        public IActionResult Remove(int id)
        {
            List<CartProductViewModel> cartProducts = GetExistingCartData();
            
            CartProductViewModel? productToRemove = cartProducts.Where(p => p.ProductID == id).FirstOrDefault();
            
            if (productToRemove != null)
            {
                cartProducts.Remove(productToRemove);

                WriteShoppingCartCookie(cartProducts);

                TempData["Message"] = "Item removed from cart!";

                return RedirectToAction("Summary");
            }
            else
            {
                TempData["Message"] = "Item not found in cart";
                return RedirectToAction("Summary");
            }

        }
        
    }
}

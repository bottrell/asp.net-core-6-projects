using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Infrastructure;
using SportsStore.Models;

//The class associated with a Razor Page is known as its page model class
//This defines handler methods that are invoked for different types of HTTP Requests, which update state before rendering the View

namespace SportsStore.Pages {

    public class CartModel : PageModel {
        private IStoreRepository repository;
        public CartModel(IStoreRepository repo, Cart cartService) {
            repository = repo;

            Cart = cartService;
        }

        public Cart Cart {get; set;}
        public string ReturnUrl {get; set;} = "/";

        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            //statefulness using session data
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(long productId, string returnUrl) {
            Product? product = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (product != null) {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new {returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(long productId, string returnUrl) {
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductID == productId).Product);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }


}
namespace LanguageFeatures.Controllers {
    public class HomeController : Controller {

        //ViewResult is derived from IActionResult, other ActionResult Subtypes are:
        /*
        PartialViewResult
        EmptyResult
        RedirectResult
        RedirectToRouteResult
        JsonResult
        JavaScriptResult
        ContentResult
        FileContentResult
        FileStreamResult
        FilePathResult
        */
        public ViewResult Index() {
            //Checking for null values
            //products needs to be nullable and we need to do some explicit checking for null values
            Product?[] products = Product.GetProducts();
            Product? p = products[2];

            //an especially verbose way of avoiding a null. The compiler recognizes that we're guarding against the null and no longer warns us
            /*
            string val;
            if (p != null) {
                val = p.Name;
            } else {
                val = "Empty";
            }
            */

            //a more elegant way of avoiding a null
            /*
            if (p != null) {
                return View(new string[] {p.Name});
            } else {
                return View(new string[] {"No value"});
            }
            */

            //an even MORE elegant way of avoiding null
            //combing the null conditional operator (?) and the null coalescing operator (??)
            return View(new string[] {p?.Name ?? "No Value"});

        }

        public ViewResult ExtensionMethodTest() {
            ShoppingCart cart = new ShoppingCart {Products = Product.GetProducts()};
            decimal cartTotal = cart.TotalPrices();
            return View("Index", new string[] {$"Total:{cartTotal:C2}"});
        }

        Product[] productArray = {
            new Product {Name = "Gummy Worms", Price = 10M},
            new Product {Name = "Yoga Block", Price = 50M},
            new Product {Name = "GTX 1080", Price = 250M},
            new Product {Name = "Literally just worms", Price = 5M}
            };
        
        public ViewResult LambdaExpressionTest() {
            //we added an extension method to the IEnumerable interface to Filter on a lambda function that we pass into filter
            decimal priceFilterTotal = productArray.Filter(p => (p?.Price?? 0) >= 20).TotalPrices();
            decimal nameFilterTotal = productArray.Filter(p => p?.Name?[0] == 'S').TotalPrices();
            return View("Index", new string[] {$"Filtered Price is {priceFilterTotal}"});
        }

        public ViewResult JordanTest(string name) {
            return View("Index", new string[] {$"You selected the {name} page!"});
        }
    }
}
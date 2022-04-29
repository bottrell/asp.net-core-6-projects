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
    }
}
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers{

    public class HomeController : Controller {
        public IActionResult Index() {
            //We don't need to specify a view because by default ASP.NET MVC looks for a view
            //that matches the naming of the action method
            return View();
        }

        [HttpGet]
        public IActionResult RsvpForm() {
            return View();
        }

        [HttpPost]
        public IActionResult RsvpForm(GuestResponse guestResponse) {
            //The base controller class provides a property called ModelState
            //that will provide the details of the model binding process
            if (ModelState.IsValid) {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            //If the validation fails, ModelState.IsValid returns false
            //When the view is rendered, Razor has access to the validation details
            //and tag helpers can be used to access the details and display to the user
            return View();
        }

        public IActionResult ListResponses() {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
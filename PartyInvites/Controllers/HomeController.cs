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
            //TODO, actually store response from guests
            return View();
        }
    }
}
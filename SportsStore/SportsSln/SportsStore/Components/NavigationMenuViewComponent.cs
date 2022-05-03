using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Components {

    public class NavigationMenuViewComponent : ViewComponent {
        private IStoreRepository repository;

        public NavigationMenuViewComponent(IStoreRepository repo) {
            repository = repo;
        }

        //The ViewComponent base calss provides access to context objects through a set of properties
        //One of the properties is called "RouteData", which provides information about how the request
        //URL was handled by the routing system
        public IViewComponentResult Invoke() {
            //dynamically assinged SelectedCategory to the ViewBag object and set it's value to the current category
            //This is obtained through the context object returned by the RouteData property
            //Viewbag is dynamic and allows me to define new properties simply by assigning values to them
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(repository.Products
                        .Select(x => x.Category)
                        .Distinct()
                        .OrderBy(x => x));
        }



    }

}
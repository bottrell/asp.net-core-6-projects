using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;

namespace SportsStore.Controllers {

    public class HomeController : Controller {

        private IStoreRepository _repository;
        public int PageSize = 4;

        //This is your first example of real dependency injection!
        //When ASP.NET Core needs to create a new instance of HomeController, it will inspect the costructor and see that it requires an object
        //that implements the IStoreRepository interface. To determine which implementation should be used, ASP.NET Core consults the configuration
        //created in Program.cs, which tells it that EFStoreRepository should be used and that a new instance should be created for every request.
        //This allows the HomeController object to access the application's repository through IStoreRepository interface without knowing
        //what implementation has been configured.
        public HomeController(IStoreRepository repo) {
            _repository = repo;
        }
        public ViewResult Index(int productPage = 1) => View(_repository.Products
                                                            .OrderBy(p => p.ProductID)
                                                            .Skip((productPage - 1) * PageSize)
                                                            .Take(PageSize));
        
    }

}
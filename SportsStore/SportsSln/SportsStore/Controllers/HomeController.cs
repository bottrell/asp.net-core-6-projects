using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;

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

        //Passes a ProductsListViewModel object as the model data to the view
        public ViewResult Index(string? category, int productPage = 1) => View(new ProductsListViewModel {
            Products = _repository.Products
                                  .Where(p => category==null || p.Category == category)
                                  .OrderBy(p=>p.ProductID)
                                  .Skip((productPage - 1) * PageSize)
                                  .Take(PageSize), 
            PagingInfo = new PagingInfo {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = category == null 
                            ? _repository.Products.Count()
                            : _repository.Products.Where(e => e.Category == category).Count()
            },
            CurrentCategory = category
        });
        
    }

}
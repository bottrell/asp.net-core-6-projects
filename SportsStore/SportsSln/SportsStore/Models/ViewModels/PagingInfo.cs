//This is a ViewModel.
//ViewModels are primarily used to pass data between a controller and a view

namespace SportsStore.Models.ViewModels {
    public class PagingInfo {
        public int TotalItems {get; set;}
        public int ItemsPerPage {get;set;}
        public int CurrentPage {get; set;}

        public int TotalPages => (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
    }
}
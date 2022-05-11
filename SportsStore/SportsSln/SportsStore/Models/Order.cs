//Allows us to add data validations
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace SportsStore.Models {

    public class Order {
        //BindNever specifies that the user can never supply values for these properties in an HTTP requrest
        //Stops ASP.NET Core from using values from the HTTP request to populate sensitive or important model properties
        [BindNever]
        public int OrderID {get; set;}
        [BindNever]
        public ICollection<CartLine> Lines {get; set;} = new List<CartLine>();
        [Required(ErrorMessage="Please enter a name")]
        public string? Name {get; set;}

        [Required(ErrorMessage = "Please enter the first address line")]
        public string? Line1 {get; set;}
        public string? Line2 {get; set;}
        public string? Line3 {get; set;}

        [Required(ErrorMessage = "Please enter a city name")]
        public string? City {get; set;}
    
        [Required(ErrorMessage = "Please enter a state name")]
        public string? State {get; set;}

        public string? Zip {get; set;}

        [Required(ErrorMessage = "Please enter a country name")]
        public string? Country {get; set;}

        public bool GiftWrap {get; set;}
    }
}
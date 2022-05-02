//A class that extends the ShoppingCart class (useful if you do not have access to the source code)
namespace LanguageFeatures.Models{
    //Extension classes are statically defined in the same namespace as the class that the method applies
    public static class MyExtensionMethods {
        //extension methods are also static 
        //The this keyword in front of the first parameter marks TotalPrices as an extension method.
        public static decimal TotalPrices (this IEnumerable<Product?> products) {
            decimal total = 0;
            if (products !=null) {
                foreach (Product? prod in products) {
                    total += prod?.Price ?? 0;
                }
            }
            return total;
        }

        public static IEnumerable<Product?> FilterByPrice (this IEnumerable<Product?> productEnum, decimal minimumPrice) {
            //iterate through all the IEnumerates and filter on items that meet it's criteria. Including null checking.
            foreach (Product? prod in productEnum) {
                if((prod?.Price ?? 0) >= minimumPrice) {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product?> FilterByName (this IEnumerable<Product?> productEnum, char firstLetter) {
            foreach (Product? prod in productEnum) {
                if (prod?.Name[0] == firstLetter) {
                    yield return prod;
                }
            }
        }

        public static IEnumerable<Product?> Filter (this IEnumerable<Product?> productEnum, Func<Product?, bool> selector) {
            foreach (Product? prod in productEnum) {
                if (selector(prod)) {
                    yield return prod;
                }
            }
        }
    }
}
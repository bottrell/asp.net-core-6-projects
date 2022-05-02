using System.Collections;

namespace LanguageFeatures.Models {
    public class ShoppingCart : IEnumerable<Product?> {

        //so this will represent an IEnumerable that can be null and the objects inside can also be null
        public IEnumerable<Product?>? Products {get; set;}

        public IEnumerator<Product?> GetEnumerator() => Products?.GetEnumerator() ?? Enumerable.Empty<Product?>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
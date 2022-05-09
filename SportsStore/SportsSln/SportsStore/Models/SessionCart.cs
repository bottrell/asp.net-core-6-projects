using System.Text.Json.Serialization;
using SportsStore.Infrastructure;

//The SessionCart class subclasses the cart class and overrides the AddItem, RemoveLine, and Clear methods 
//so they call the base implmenetations and then store the updated state in the session using the extension methods on the ISession interface
namespace SportsStore.Models {

    public class SessionCart : Cart {

        //GetCart is a factory for creating SessionCart objects and providing them with an ISession object so they can store themselves
        public static Cart GetCart(IServiceProvider services) {
            ISession? session = services.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
            SessionCart cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession? Session {get; set;}

        public override void AddItem(Product product, int quantity) {
            base.AddItem(product, quantity);
            Session?.SetJson("Cart", this);
        }

        public override void RemoveLine(Product product) {
            base.RemoveLine(product);
            Session?.SetJson("Cart", this);
        }

        public override void Clear() {
            base.Clear();
            Session?.Remove("Cart");
        }
    }
}
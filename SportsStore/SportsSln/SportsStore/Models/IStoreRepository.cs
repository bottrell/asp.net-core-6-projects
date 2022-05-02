// Repository class - some people think this isn't necessary, 
//but it reduces duplication and ensures that operations on the database are performed consistently
namespace SportsStore.Models {
    public interface IStoreRepository {

        //The interface IQueryable<T> allows a caller to obtain a sequence of Product objects
        //IQueryable<T> represents a collection of objects that can be queried, such as those managed by a database

        //IQueryable allows us to ask the database for just objects that I require using LINQ statments
        //Basically, IEnumerable would require us to gather all the objects from the database and delete those that we don't want
        //Each time the collection of objects is enumerated, the query will be evaluated again
        //So we can convert the IQueryable<T> interface using the ToList or ToArray extension methods
        IQueryable<Product> Products {get; }

    }
}
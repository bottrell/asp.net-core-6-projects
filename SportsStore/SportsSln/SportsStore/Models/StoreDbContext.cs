using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models {

    /*
        The DbContext base class provides access to Entity Framework Core's underlying functionality, and the Products
        property will provide access to the Product objects in the database.

        The StoreDbContext class is derived from DbContext and adds the properties that will be used to read and write the
        applications data.
     */
    public class StoreDbContext : DbContext {
        public StoreDbContext(DbcontextOptions<StoreDbContext> options) : base(options) {}

        public DbSet<Product> Products => Set<Product>();
    }
}
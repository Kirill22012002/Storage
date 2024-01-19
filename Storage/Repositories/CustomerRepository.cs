using System.Linq;
using Storage.Context;

namespace Storage.Repositories
{
    public class CustomerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CustomerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public object GetCustomer(long customerId)
        {
            var customer = _dbContext.Customers
                .FirstOrDefault(c => c.Id == customerId);


            var products = _dbContext.Products
                .SelectMany(
                    p => _dbContext.CustomersProducts.Where(cp => cp.IdCustomer == customerId && cp.IdProduct == p.Id),
                    (p, cp) => new
                    {
                        Id = p.Id,
                        Title = p.Title
                    });

            var model = new
            {
                Name = customer?.Name,
                Age = customer?.Age,
                Products = products
            };
                
            return model;
        }
    }
}
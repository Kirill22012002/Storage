using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.DbModels;

namespace Storage.Repositories
{
    public class ProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<object> GetProductsWithPartAndCell()
        {
            var query = await _dbContext.Products
                .SelectMany(
                    product => _dbContext.Parts.Where(part => part.IdProduct == product.Id).DefaultIfEmpty(),
                    (product, part) => new { product.Title, part })
                .SelectMany(
                    x => _dbContext.Records.Where(record => record.IdPart == x.part.Id).DefaultIfEmpty(),
                    (x, record) => new { x.Title, x.part, record })
                .SelectMany(
                    x => _dbContext.Cells.Where(cell => cell.Id == x.record.IdCell).DefaultIfEmpty(),
                    (x, cell) => new
                    {
                        ProductTitle = x.Title,
                        PartAmount = x.part.Amount,
                        PartDateFiling = x.part.Datefiling,
                        CellTitle = cell.Title
                    })
                .ToListAsync();

            return query;
        }
    }
}
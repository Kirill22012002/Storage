using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.Models;

namespace Storage.Repositories
{
    public class PartRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PartRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductWithInfoDto>> GetInfoByBarcodeAsync(string barcode)
        {
            var query = await _dbContext.Parts
                .Where(part => part.Barcode == barcode)
                .Select(part => new
                {
                    Part = part,
                    Product = part.IdProductNavigation
                })
                .SelectMany(
                    x => _dbContext.Records.Where(record => record.IdPart == x.Part.Id).DefaultIfEmpty(),
                    (x, record) => new { x, record })
                .SelectMany(
                    x => _dbContext.Cells.Where(cell => cell.Id == x.record.IdCell).DefaultIfEmpty(),
                    (x, cell) => new ProductWithInfoDto
                    {
                        Name = x.x.Product.Title,
                        Amount = x.x.Part.Amount,
                        Datefiling = x.x.Part.Datefiling,
                        Barcode = x.x.Part.Barcode,
                        Cell = cell.Title
                    })
                .ToListAsync();

            return query;
        }
    }
}
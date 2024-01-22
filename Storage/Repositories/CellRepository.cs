using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.Models;

namespace Storage.Repositories
{
    public class CellRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CellRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // ToDo this is doesn't work. it is necessary to get free cell without parts
        public async Task<object> GetFreeCellAsync()
        {
            var query = await _dbContext.Cells
                .SelectMany(
                    cell => _dbContext.Records.DefaultIfEmpty(),
                    (cell, record) => new { cell, record })
                .OrderBy(x => x.record.IdPart)
                .Select(x => new CellDto()
                {
                    Id = x.cell.Id, 
                    Title = x.cell.Title
                })
                .FirstAsync();

            return query;
        }
    }
}
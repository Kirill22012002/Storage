using Microsoft.EntityFrameworkCore;
using Storage.Context;
using Storage.DbModels;

namespace Storage.Repositories
{
    public abstract class BaseRepository<T> where T : BaseModel
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<T>();
        }
        
    }
}
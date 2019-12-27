using Microsoft.EntityFrameworkCore;

namespace DUR.Api.Repo.Database
{
    public class DbSetBase<T> where T : class
    {
        private readonly RepositoryContext _dataContext;
        private readonly DbSet<T> _dbSet;

        public DbSet<T> DbSet
        {
            get { return _dbSet; }
        }

        public RepositoryContext DataContext
        {
            get { return _dataContext; }
        }

        public DbSetBase(RepositoryContext dataContext)
        {
            _dataContext = dataContext;
            _dbSet = _dataContext.Set<T>();
        }

    }
}

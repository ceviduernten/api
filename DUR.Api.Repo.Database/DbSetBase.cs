using Microsoft.EntityFrameworkCore;

namespace DUR.Api.Repo.Database;

public class DbSetBase<T> where T : class
{
    public DbSetBase(RepositoryContext dataContext)
    {
        DataContext = dataContext;
        DbSet = DataContext.Set<T>();
    }

    public DbSet<T> DbSet { get; }

    public RepositoryContext DataContext { get; }
}
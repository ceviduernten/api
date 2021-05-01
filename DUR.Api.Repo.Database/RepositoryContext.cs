using DUR.Api.Repo.Database.Configurations;
using DUR.Api.Settings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;

namespace DUR.Api.Repo.Database
{
    public class RepositoryContext : DbContext
    {
        private readonly Guid _contextDb;
        public Guid ContextId { get { return _contextDb; } }
        private readonly IOptions<DatabaseOptions> _databaseOptions;

        public RepositoryContext(IOptions<DatabaseOptions> options) : base()
        {
            _contextDb = Guid.NewGuid();
            _databaseOptions = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentConfiguration());
            modelBuilder.ApplyConfiguration(new AppointmentResponseConfiguration());
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new StorageLocationConfiguration());
            modelBuilder.ApplyConfiguration(new BoxConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new EasterCityConfiguration());
            modelBuilder.ApplyConfiguration(new EasterLocationConfiguration());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_databaseOptions.Value.Database, x => x.MigrationsAssembly("DUR.Api.Web"));
        }

    }
}

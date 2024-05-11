using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using XPIncInvest.Domain.Abstractions;

namespace XPIncInvest.Infrastructure.Context
{
    public class DataContext : DbContext, IUnitOfWork
    {

        protected readonly IConfiguration Configuration;

        public DataContext(DbContextOptions options, IConfiguration configuration) : base(options) 
        {
            Configuration = configuration;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
   

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=mysecretpassword");
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> Commit()
        {
            var success = (await base.SaveChangesAsync()) > 0;

            base.SaveChanges();
            return success;
        }
        public void Dispose() => base.Dispose();

        public Task Rollback()
        {
            // Rollback anything, if necessary
            return Task.CompletedTask;
        }
    }
}

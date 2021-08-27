using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace A2ZPortal.Core.Entities.Context
{
    public class PortalContext : DbContext
    {
        private readonly string _connectionString;

        public PortalContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
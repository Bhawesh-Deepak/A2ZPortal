using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace A2ZPortal.Core.Entities.Context
{
    public class PortalContext : DbContext
    {
        private readonly string _connectionString;

        public PortalContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetSection("ConnectionStrings:dbConnection").Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<ModuleMaster> ModuleMasters { get; set; }
        public virtual DbSet<PropertyStatusModel> PropertyStatus { get; set; }
        public virtual DbSet<PropertyDetail> PropertyDetails { get; set; }
        public virtual DbSet<PropertyImage> PropertyImages { get; set; }
        public virtual DbSet<PropertyType> PropertyTypes { get; set; }
        public virtual DbSet<RoleMaster> RoleMasters { get; set; }
        public virtual DbSet<BathRoom> BathRooms { get; set; }
        public virtual DbSet<BedRoom> BedRooms { get; set; }
        public virtual DbSet<Budget> Budgets { get; set; }
        public virtual DbSet<PropertyFeature> PropertyFeatures { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }

    }
}
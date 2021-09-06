using A2ZPortal.Core.Entities.Master;
using A2ZPortal.Core.Entities.Property;
using A2ZPortal.Core.Entities.UserManagement;
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
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<SubLocation> SubLocations { get; set; }
        public virtual DbSet<SubModuleMaster> SubModuleMasters { get; set; }
        public virtual DbSet<AreaType> AreaTypes { get; set; }
        public virtual DbSet<AreaMeasurement> AreaMeasurements { get; set; }
        public virtual DbSet<AdditionalRoom> AdditionalRooms { get; set; }
        public virtual DbSet<PossessionStatus> PossessionStatuss { get; set; }
        public virtual DbSet<FurnishedStatus> FurnishedStatuss { get; set; }
        public virtual DbSet<AgeOfProperty> AgeOfPropertys { get; set; }
        public virtual DbSet<NumberOfParking> NumberOfParkings { get; set; }
        public virtual DbSet<Amenities> Amenitiess { get; set; }
        public virtual DbSet<ViewFacing> ViewFacings { get; set; }
        public virtual DbSet<DefiningLocation> DefiningLocations { get; set; }
        public virtual DbSet<ExplaningPrice> ExplaningPrices { get; set; }
        public virtual DbSet<SizeAndStructure> SizeAndStructures { get; set; }
        public virtual DbSet<SuitableFor> SuitableFors { get; set; }
        public virtual DbSet<ExplaningProperty> ExplaningPropertys { get; set; }
        public virtual DbSet<RoleAccessDetail> RoleAccessDetails { get; set; }
        
    }
}
using Microsoft.EntityFrameworkCore;

namespace Domain.Core
{
    public partial class AfpCrecerDbContext : DbContext
    {
        public AfpCrecerDbContext(DbContextOptions<AfpCrecerDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyMedicalCenterConfigurations(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }    
}

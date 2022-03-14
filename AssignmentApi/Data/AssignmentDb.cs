using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Data
{
    public class AssignmentDb : DbContext
    {
        public AssignmentDb(DbContextOptions<AssignmentDb> options) : base(options)
        {

        }

        public virtual DbSet<Record> Records { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Record>().Property(o => o.Mass).HasPrecision(15, 2);
            modelBuilder.Entity<Record>().Property(o => o.Velocity).HasPrecision(20, 2);
            modelBuilder.Entity<Record>().Property(o => o.Energy).HasPrecision(33, 2);
        }
    }
}

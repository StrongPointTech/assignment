using Microsoft.EntityFrameworkCore;

namespace AssignmentApi.Data
{
    public class AssignmentDb : DbContext
    {
        public AssignmentDb(DbContextOptions<AssignmentDb> options) : base(options)
        {

        }

        public virtual DbSet<Record> Records { get; set; }

    }
}

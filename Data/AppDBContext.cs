using Assignment.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Assignment.Data
{
    public class AppDBContext:DbContext
    {
        public DbSet<DocumentCenter> DocumentCenters { get; set; }
        public DbSet<DivisionMaster> DivisionMasters { get; set; }
        public DbSet<DepartmentMaster> DepartmentMasters { get; set; }
        public DbSet<OfficeMaster> OfficeMasters { get; set; }

        public AppDBContext(DbContextOptions<AppDBContext> options):base(options)
        {
            
        }
      
    }
}

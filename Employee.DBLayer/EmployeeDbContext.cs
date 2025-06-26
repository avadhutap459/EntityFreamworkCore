using Employee.DBLayer.DBModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.DBLayer
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext() { }

        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options) : base(options) 
        {
            
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClsEmployee>().HasOne(x => x.clsDepartment).WithMany(x => x.employees).HasForeignKey(x => x.departmentid).OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder.Entity<ClsEmpCountBaseDep>(e => e.HasNoKey());

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ClsEmployee> Employees { get; set; }
        public DbSet<ClsDepartment> Department { get; set; }

        public DbSet<Cake> cakes { get; set; }
        public DbSet<ClsUser> users { get; set; }
        public virtual DbSet<ClsEmpCountBaseDep> ClsEmpCountBaseDep { get; set; }

    }
}

using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using EmployeeListing.Model.Employee;
using EmployeeListing.Model.AuthUser;


namespace EmployeeListing.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

       
        public DbSet<EmpDTO> TBL_Employees { get; set; }

        public DbSet<AuthUserpropDTO> TBL_UserAuthentication { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure primary key for Employee entity (if needed)
            modelBuilder.Entity<EmpDTO>().HasKey(e => e.AutoId);
            modelBuilder.Entity<AuthUserpropDTO>().HasKey(e => e.UserName);
        }

       

      



    }
}

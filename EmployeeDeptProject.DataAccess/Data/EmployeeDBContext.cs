using EmployeeDeptProject.Models.Models;
using EmployeeDeptProject.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDeptProject.DataAccess.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext()
        {
        }

        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
           : base(options)
        {


        }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Login> Logins { get; set; }
        
    }
}

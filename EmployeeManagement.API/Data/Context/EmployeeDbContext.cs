using EmployeeManagement.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.API.Data.Context
{
    public class EmployeeDbContext : DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Employee> Employees { get; set; }


    }
}

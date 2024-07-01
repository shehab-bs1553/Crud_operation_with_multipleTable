using Microsoft.EntityFrameworkCore;
using work_with_multiple_table.Models;

namespace work_with_multiple_table.Data
{
    public class ApplicationContext : DbContext
    {
       public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }
    }
}

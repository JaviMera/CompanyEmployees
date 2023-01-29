using CompanyEmployees.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CompanyEmployees.Repository
{

    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var companies = new List<Company> { 
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "IT_Solutions Ltd",
                    Address = "583 Wall Dr. Gwynn Oak, MD 21207",
                    Country = "USA"
                }, 
                new Company
                {
                    Id = Guid.NewGuid(),
                    Name = "Admin_Solutions Ltd",
                    Address = "312 Forest Avenue, BF 923",
                    Country = "USA"
                }
            };
            modelBuilder.ApplyConfiguration(new CompanyConfiguration(companies));
            modelBuilder.ApplyConfiguration(new EmployeeConfiguration(companies.Select(x => x.Id).ToArray()));
        }
        public DbSet<Company>? Companies { get; set; }
        public DbSet<Employee>? Employees { get;}
    }
}
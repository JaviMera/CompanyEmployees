using CompanyEmployees.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.Repository
{
    public sealed class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        private readonly Guid[] _companyKeys;

        public EmployeeConfiguration(Guid[] companyKeys)
        {            
            _companyKeys = companyKeys;
        }

        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasData(
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Sam Raiden",
                    Age = 26,
                    Position = "Software developer",
                    CompanyId = _companyKeys[new Random().Next(0, _companyKeys.Length)]
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Jana McLeaf",
                    Age = 30,
                    Position = "Software developer",
                    CompanyId = _companyKeys[new Random().Next(0, _companyKeys.Length)]
                },
                new Employee
                {
                    Id = Guid.NewGuid(),
                    Name = "Kane Miller",
                    Age = 35,
                    Position = "Administrator",
                    CompanyId = _companyKeys[new Random().Next(0, _companyKeys.Length)]
                }
            );
        }
    }
}
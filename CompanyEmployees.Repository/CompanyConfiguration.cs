using CompanyEmployees.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CompanyEmployees.Repository
{
    public sealed class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        private IEnumerable<Company> _companies;

        public CompanyConfiguration(IEnumerable<Company> companies)
        {
            _companies = companies;
        }

        public void Configure(EntityTypeBuilder<Company> builder)
        {
            foreach (var company in _companies)
            {
                builder.HasData(company);
            }
        }
    }
}
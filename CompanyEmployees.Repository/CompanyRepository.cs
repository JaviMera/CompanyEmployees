using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Repository
{
    public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateCompany(Company company)
        {
            Create(company);
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(company => company.Name)
                .ToList();
        }

        public Company? GetCompany(Guid companyId, bool trackChanges)
        {
            return FindByCondition(company => company.Id.Equals(companyId), trackChanges)
                .SingleOrDefault();
        }
    }
}

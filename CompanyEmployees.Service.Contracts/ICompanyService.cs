using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
    }
}
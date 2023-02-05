using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto? GetCompany(Guid companyId, bool trackChanges);
    }
}
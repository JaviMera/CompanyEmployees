using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service.Contracts
{
    public interface ICompanyService
    {
        IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges);
        CompanyDto? GetCompany(Guid companyId, bool trackChanges);
        CompanyDto CreateCompany(CompanyForCreationDto company);
        IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);
        (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companies);
    }
}
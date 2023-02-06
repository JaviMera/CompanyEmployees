using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service.Contracts
{
    public interface IEmployeeService 
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
    }
}
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
    }
}
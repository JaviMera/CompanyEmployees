using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Repository
{
    public sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges)
        {
            return FindByCondition(employee => employee.CompanyId.Equals(companyId), trackChanges)
                .OrderBy(employee => employee.Name)
                .ToList();
        }
    }
}

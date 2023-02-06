using AutoMapper;
using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Exceptions;
using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public EmployeeService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if(company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employees = _repositoryManager.Employee.GetEmployees(companyId, trackChanges);

            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return employeesDto;
        }
    }
}
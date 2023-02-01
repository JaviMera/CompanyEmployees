using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Service.Contracts;

namespace CompanyEmployees.Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            try
            {
                return _repositoryManager.Company.GetAllCompanies(trackChanges);
            }
            catch (Exception exception)
            {
                _loggerManager.LogError($"Something went wrong in the {nameof(GetAllCompanies)} service method {exception}");
                throw;
            }
        }
    }
}
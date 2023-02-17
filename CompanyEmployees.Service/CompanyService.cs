using AutoMapper;
using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Exceptions;
using CompanyEmployees.Entities.Models;
using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service
{
    internal sealed class CompanyService : ICompanyService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;

        public CompanyService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
        }

        public CompanyDto CreateCompany(CompanyForCreationDto company)
        {
            var companyEntity = _mapper.Map<Company>(company);
            _repositoryManager.Company.CreateCompany(companyEntity);
            _repositoryManager.Save();

            return _mapper.Map<CompanyDto>(companyEntity);
        }

        public (IEnumerable<CompanyDto> companies, string ids) CreateCompanyCollection(IEnumerable<CompanyForCreationDto> companies)
        {
            if(companies is null)
            {
                throw new CompanyCollectionBadRequest();
            }

            var companyEntities = _mapper.Map<IEnumerable<Company>>(companies);

            foreach(var company in companyEntities)
            {
                _repositoryManager.Company.CreateCompany(company);
            }

            _repositoryManager.Save();

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            var ids = string.Join(",", companiesToReturn.Select(c => c.Id));

            return (companies: companiesToReturn, ids: ids);
        }

        public void DeleteCompany(Guid companyId, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if(company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            _repositoryManager.Company.DeleteCompany(company);
            _repositoryManager.Save();
        }

        public IEnumerable<CompanyDto> GetAllCompanies(bool trackChanges)
        {
            var companies = _repositoryManager.Company.GetAllCompanies(trackChanges);
            var companiesDto = _mapper.Map<IEnumerable<CompanyDto>>(companies);
            return companiesDto;                            
        }

        public IEnumerable<CompanyDto> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges)
        {
            if(companyIds is null)
            {
                throw new IdParametersBadRequestException();
            }

            var companyEntities = _repositoryManager.Company.GetByIds(companyIds, trackChanges);

            if(companyEntities.Count() != companyIds.Count()) {
                throw new CollectionByIdsBadRequestException();
            }

            var companiesToReturn = _mapper.Map<IEnumerable<CompanyDto>>(companyEntities);

            return companiesToReturn;
        }

        public CompanyDto? GetCompany(Guid companyId, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if(company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var companyDto = _mapper.Map<CompanyDto>(company);

            return companyDto;
        }
    }
}
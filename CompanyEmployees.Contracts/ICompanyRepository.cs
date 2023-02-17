﻿using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Contracts
{
    public interface ICompanyRepository
    {
        IEnumerable<Company> GetAllCompanies(bool trackChanges);
        Company? GetCompany(Guid companyId, bool trackChanges);
        void CreateCompany(Company company);
        IEnumerable<Company> GetByIds(IEnumerable<Guid> companyIds, bool trackChanges);
        void DeleteCompany(Company company);
    }
}
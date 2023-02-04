﻿using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Repository
{
    public sealed class CompanyRepository : RepositoryBase<Company>, ICompanyRepository
    {
        public CompanyRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<Company> GetAllCompanies(bool trackChanges)
        {
            return FindAll(trackChanges)
                .OrderBy(company => company.Name)
                .ToList();
        }
    }
}
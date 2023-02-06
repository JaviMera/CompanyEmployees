﻿using CompanyEmployees.Entities.Models;

namespace CompanyEmployees.Contracts
{
    public interface IEmployeeRepository
    {
        IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges);
        Employee? GetEmployee(Guid companyId, Guid employeeId, bool trackChanges);
    }
}
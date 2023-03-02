﻿using CompanyEmployees.Entities.Models;
using CompanyEmployees.Shared.DataTransferObjects;

namespace CompanyEmployees.Service.Contracts
{
    public interface IEmployeeService 
    {
        IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges);
        EmployeeDto GetComployee(Guid companyId, Guid employeeId, bool trackChanges);
        EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges);
        void DeleteEmployeeForCompany(Guid companyId, Guid employeeId, bool trackChanges);
        void UpdateEmployeeForCompany(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges);
        (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(
            Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges);

        void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
    }
}
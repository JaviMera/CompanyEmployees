﻿using AutoMapper;
using CompanyEmployees.Contracts;
using CompanyEmployees.Entities.Exceptions;
using CompanyEmployees.Entities.Models;
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

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);

            _repositoryManager.Employee.CreatEmployeeForCompany(companyId, employeeEntity);
            _repositoryManager.Save();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;
        }

        public void DeleteEmployeeForCompany(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeForCompany = _repositoryManager.Employee.GetEmployee(companyId, employeeId, trackChanges);

            if(employeeForCompany is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }

            _repositoryManager.Employee.DeleteEmployee(employeeForCompany);
            _repositoryManager.Save();
        }

        public EmployeeDto GetComployee(Guid companyId, Guid employeeId, bool trackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, trackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employee = _repositoryManager.Employee.GetEmployee(companyId, employeeId, trackChanges);

            if (employee is null)
            {
                throw new EmployeeNotFoundException(companyId);
            }

            return _mapper.Map<EmployeeDto>(employee);
        }

        public (EmployeeForUpdateDto employeeToPatch, Employee employeeEntity) GetEmployeeForPatch(Guid companyId, Guid employeeId, bool compTrackChanges, bool empTrackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, compTrackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeEntity = _repositoryManager.Employee.GetEmployee(companyId, employeeId, empTrackChanges);

            if(employeeEntity is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }

            var employeeToPatch = _mapper.Map<EmployeeForUpdateDto>(employeeEntity);

            return (employeeToPatch, employeeEntity);
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

        public void SaveChangesForPatch(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)
        {
            var employee = _mapper.Map(employeeToPatch, employeeEntity);
            _repositoryManager.Save();
        }

        public void UpdateEmployeeForCompany(Guid companyId, Guid employeeId, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges)
        {
            var company = _repositoryManager.Company.GetCompany(companyId, compTrackChanges);

            if (company is null)
            {
                throw new CompanyNotFoundException(companyId);
            }

            var employeeEntity = _repositoryManager.Employee.GetEmployee(companyId, employeeId, empTrackChanges);

            if (employeeEntity is null)
            {
                throw new EmployeeNotFoundException(employeeId);
            }

            _mapper.Map(employeeForUpdate, employeeEntity);
            _repositoryManager.Save();
        }
    }
}
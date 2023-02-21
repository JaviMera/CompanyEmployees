using CompanyEmployees.Service.Contracts;
using CompanyEmployees.Shared.DataTransferObjects;
using Microsoft.AspNetCore.Mvc;

namespace CompanyEmployees.Presentation.Controllers
{
    [Route("api/companies/{companyId}/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IServiceManager _service;

        public EmployeesController(IServiceManager serviceManager)
        {
            _service = serviceManager;
        }

        [HttpGet]
        public IActionResult GetEmployeesForCompany(Guid companyId)
        {
            var employees = _service.EmployeeService.GetEmployees(companyId, trackChanges: false);

            return Ok(employees);
        }

        [HttpGet]
        [Route("{id:guid}", Name = "GetEmployeeForCompany")]
        public IActionResult GetEmployeeForCompany(Guid companyId, Guid id)
        {
            var employee = _service.EmployeeService.GetComployee(companyId, id, trackChanges: false);

            return Ok(employee);
        }

        [HttpPost]
        public IActionResult CreateEmployeeForCompany(Guid companyId, [FromBody] EmployeeForCreationDto employee)
        {
            if (employee is null)
            {
                return BadRequest("EmployeeForCreationDto object is null.");
            }

            var employeeToReturn = _service.EmployeeService.CreateEmployeeForCompany(companyId, employee, trackChanges: false);

            return CreatedAtRoute("GetEmployeeForCompany", new { companyId, id = employeeToReturn.Id }, employeeToReturn);
        }

        [HttpDelete("{employeeId:guid}")]
        public IActionResult DeleteEmployeeForCompany(Guid companyId, Guid employeeId)
        {
            _service.EmployeeService.DeleteEmployeeForCompany(companyId, employeeId, false);

            return NoContent();
        }

        [HttpPut("{employeeId:guid}")]
        public IActionResult UpdateEmployeeForCompany(Guid companyId, Guid employeeId, [FromBody] EmployeeForUpdateDto employee)
        {
            if (employee is null)
            {
                return BadRequest("EmployeeForUpdateDto object is null");
            }

            _service.EmployeeService.UpdateEmployeeForCompany(companyId, employeeId, employee, compTrackChanges: false, empTrackChanges: true);

            return NoContent();
        }
    }
}

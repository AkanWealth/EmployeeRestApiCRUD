using EmployeeRestApiCRUD.EmployeeData;
using EmployeeRestApiCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeRestApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private IEmployeeData _employeeData;
        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet("{id}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _employeeData.GetEmployeeById(id);

                if(employee != null)
            {
                return Ok(employee);
            }
            return NotFound("Employee was not found");
        }

        [HttpPost]
        public IActionResult GetEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployeeById(id);

            if(employee != null)
            {
                _employeeData.DeleteEmployee(employee);
                return Ok("Employee has be removed");
            }
            return NotFound("Employee was not found");
        }

        [HttpPatch("{id}")]
        public IActionResult Employee(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployeeById(id);

            if(existingEmployee != null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}

using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MasGlobal.Employee.API.Exceptions;
using MasGlobal.Employees.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace MasGlobal.Employee.API.Controllers
{
    [Route("api/v1/[controller]")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new EmployeeApiArgumentNullException(nameof(employeeService));
        }

        /// <summary>
        /// Returns an employee that matches with the specified id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Returns an employee that matches with the specified id</returns>
        /// <response code="200">Returns an Employee object that matches with the specified id</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(Employees.Business.Model.Employee), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _employeeService.GetEmployeeAsync(id);

            if (employee == null)
                return NotFound();

            return Ok(employee);
        }

        /// <summary>
        /// Returns a list of employees
        /// </summary>
        /// <returns>Returns a list of employees</returns>
        /// <response code="200">Returns a list of employees</response>
        [HttpGet]
        [ProducesResponseType(typeof(List<Employees.Business.Model.Employee>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _employeeService.GetEmployeesAsync();

            if (employees == null || employees.Count == 0)
                return NotFound();

            return Ok(employees);
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MasGlobal.Employees.Business.Factories;
using MasGlobal.Employees.Business.Model;
using MasGlobal.Employees.DataAccess.Repository;

namespace MasGlobal.Employees.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeeFactory _employeeFactory;

        public EmployeeService(IEmployeesRepository employeesRepository, IEmployeeFactory employeeFactory)
        {
            _employeesRepository = employeesRepository;
            _employeeFactory = employeeFactory;
        }

        public async Task<Employee> GetEmployeeAsync(int id)
        {
            var employeeInfo = await _employeesRepository.GetEmployeAsync(id);
            return employeeInfo == null ? null : _employeeFactory.CreateEmployee(employeeInfo);
        }

        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var employeesInfo = await _employeesRepository.GetEmployeesAsync();
            return employeesInfo == null ? null : _employeeFactory.CreateEmployees(employeesInfo.ToList());
        }
    }
}

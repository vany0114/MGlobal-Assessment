using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobal.Employees.Business.Model;

namespace MasGlobal.Employees.Business.Services
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeAsync(int id);

        Task<List<Employee>> GetEmployeesAsync();
    }
}
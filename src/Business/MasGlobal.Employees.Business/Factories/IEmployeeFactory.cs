using System.Collections.Generic;
using System.Threading.Tasks;
using Employee = MasGlobal.Employees.Business.Model.Employee;
using Entity = MasGlobal.Employees.DataAccess.Model;

namespace MasGlobal.Employees.Business.Factories
{
    public interface IEmployeeFactory
    {
        Employee CreateEmployee(Entity.Employee employeeInfo);

        List<Employee> CreateEmployees(List<Entity.Employee> employeesInfo);
    }
}
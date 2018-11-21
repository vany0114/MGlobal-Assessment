using System.Collections.Generic;
using System.Threading.Tasks;
using MasGlobal.Employees.DataAccess.Model;

namespace MasGlobal.Employees.DataAccess.Repository
{
    public interface IEmployeesRepository
    {
        Task<Employee> GetEmployeAsync(int id);

        Task<IList<Employee>> GetEmployeesAsync();
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using MasGlobal.Employees.DataAccess.Model;
using Newtonsoft.Json;

namespace MasGlobal.Employees.DataAccess.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        private readonly HttpClient _apiClient;

        public EmployeesRepository(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Employee> GetEmployeAsync(int id)
        {
            var employees = await GetEmployeesAsync();
            return employees?.FirstOrDefault(x => x.Id == id);
        }

        public async Task<IList<Employee>> GetEmployeesAsync()
        {
            var response = await _apiClient.GetAsync("Employees");
            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            return JsonConvert.DeserializeObject<List<Employee>>(await response.Content.ReadAsStringAsync());
        }
    }
}

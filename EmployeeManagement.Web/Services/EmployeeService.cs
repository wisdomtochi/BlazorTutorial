using EmployeeMangement.Models.Employee;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EmployeeManagement.Web.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly HttpClient httpClient;

        public EmployeeService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<AllEmployees> GetEmployees()
        {
            try
            {
                httpClient.BaseAddress = new Uri("http://localhost:5080");
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("/api/home/getemployees");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    var responseResult = JsonSerializer.Deserialize<AllEmployees>(result);

                    return responseResult;
                }
                return null;
            }
            catch { throw; }
        }
    }
}

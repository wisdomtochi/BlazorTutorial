using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeDetails;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorApp.Services.Implementation
{
    public class EmployeeDetailsService : IEmployeeDetailsService
    {
        private readonly HttpClient httpClient;

        public EmployeeDetailsService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<GetEmployee> GetEmployee(Guid id)
        {
            try
            {
                httpClient.BaseAddress = new Uri("http://localhost:5080");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync($"/api/home/getemployee/{id}");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<GetEmployee>(result);
                }

                return null;
            }
            catch { throw; }
        }
    }
}

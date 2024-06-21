using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorApp.Services.Implementation
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly HttpClient httpClient;

        public EmployeeListService(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("http://localhost:7143");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.httpClient = httpClient;
        }

        public async Task<EmployeeList> GetEmployees()
        {
            try
            {
                var response = await httpClient.GetAsync("/api/v1/home/allemployees");
                var result = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<EmployeeList>(result);

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

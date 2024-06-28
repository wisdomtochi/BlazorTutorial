using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using System.Net.Http.Headers;
using System.Text.Json;

namespace BlazorApp.Services.Implementation
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<EmployeeListService> logger;

        public EmployeeListService(HttpClient httpClient, ILogger<EmployeeListService> logger)
        {
            httpClient.BaseAddress = new Uri("http://localhost:7143");
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            this.httpClient = httpClient;
            this.logger = logger;
        }

        public async Task<EmployeeList> GetEmployees()
        {
            try
            {
                logger.LogInformation("Get Employees Method started.");
                var response = await httpClient.GetAsync("/api/v1/home/allemployees");
                logger.LogInformation("employees gotten from api.");
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

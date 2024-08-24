using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using System.Net.Http.Headers;

namespace BlazorApp.Services.Implementation
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly HttpClient httpClient;
        private readonly ILogger<EmployeeListService> logger;

        public EmployeeListService(HttpClient httpClient, ILogger<EmployeeListService> logger)
        {
            this.httpClient = httpClient;
            this.logger = logger;

            //SetupHttpClient();
        }

        public async Task<EmployeeList> GetEmployees()
        {
            try
            {
                logger.LogInformation("Get Employees Method started.");
                //var response = await httpClient.GetAsync("/api/v1/Home/allemployees");
                //var result = await response.Content.ReadAsStringAsync();

                //var response = await httpClient.GetFromJsonAsync<EmployeeList>("/api/v1/Home/allemployees");
                try
                {
                    var response = await httpClient.GetAsync("/api/v1/HomeController/allemployees").ConfigureAwait(false);

                    if (response.IsSuccessStatusCode)
                    {
                        var result = await response.Content.ReadFromJsonAsync<EmployeeList>().ConfigureAwait(false);

                        return result;
                    }
                }
                catch (Exception ex)
                {
                    logger.LogError(ex.Message);
                }

                //return JsonSerializer.Deserialize<EmployeeList>(response);
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void SetupHttpClient()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7143");
            httpClient.DefaultRequestHeaders.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}

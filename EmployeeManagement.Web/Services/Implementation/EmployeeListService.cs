﻿using EmployeeManagement.Web.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using System.Net.Http.Headers;
using System.Text.Json;

namespace EmployeeManagement.Web.Services.Implementation
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly HttpClient httpClient;

        public EmployeeListService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<EmployeeList> GetEmployees()
        {
            try
            {
                httpClient.BaseAddress = new Uri("http://localhost:5080");
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await httpClient.GetAsync("/api/home/getemployees");
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<EmployeeList>(result);
                }

                return null;
            }
            catch { throw; }
        }
    }
}

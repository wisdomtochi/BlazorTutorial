using EmployeeManagement.Web.Services;
using EmployeeMangement.Models.Employee;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EmployeesBase : ComponentBase
    {
        [Inject]
        public IEmployeeService employeeService { get; set; }

        public AllEmployees Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await employeeService.GetEmployees();
            Employees = result;
        }
    }
}

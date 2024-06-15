using BlazorWebApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using EmployeeMangement.Models.Error;
using Microsoft.AspNetCore.Components;

namespace BlazorWebApp.Components.Pages
{
    public class AllEmployeesBase : ComponentBase
    {
        [Inject]
        public IEmployeeListService employeeService { get; set; }
        public IErrorService errorService { get; set; }

        public ErrorModel Error { get; set; }

        public EmployeeList Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await employeeService.GetEmployees();

            if (result.status != true)
            {
                var error = errorService.SetErrorMessage(result.message);

                Error = error;
            }

            Employees = result;
        }
    }
}

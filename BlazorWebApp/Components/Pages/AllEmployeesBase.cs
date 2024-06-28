using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeList;
using EmployeeMangement.Models.Error;
using Microsoft.AspNetCore.Components;

namespace BlazorApp.Components.Pages
{
    public class AllEmployeesBase : ComponentBase
    {
        [Inject]
        public ILogger<AllEmployeesBase> _logger { get; set; }
        [Inject]
        public IEmployeeListService employeeService { get; set; }
        [Inject]
        public IErrorService errorService { get; set; }

        public ErrorModel Error { get; set; }
        public EmployeeList Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _logger.LogInformation("Initializing Razor Page.");
            var result = await employeeService.GetEmployees();
            _logger.LogInformation("gotten employees from result in initializing razor page");

            if (result.status != true)
            {
                var error = errorService.SetErrorMessage(result.message);

                Error = error;
            }

            Employees = new EmployeeList() { results = [new Result() { firstname = "john", lastName = "okoro" }] };
            _logger.LogInformation("initialized razor.");
        }
    }
}

using EmployeeManagement.Web.Services.Interface;
using EmployeeMangement.Models.Employee.EmployeeDetails;
using EmployeeMangement.Models.Error;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EmployeeDetailsBase : ComponentBase
    {
        [Inject]
        public IEmployeeDetailsService employeeDetailsService { get; set; }
        public IErrorService errorService { get; set; }

        public GetEmployee Employee { get; set; } = new GetEmployee();
        public ErrorModel Error { get; set; }

        [Parameter]
        public string id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            var result = await employeeDetailsService.GetEmployeeDetails(Guid.Parse(id));

            if (result.status is true) Employee = result;

            var error = errorService.SetErrorMessage("Employee Not Found.");

            Error = error;
        }
    }
}

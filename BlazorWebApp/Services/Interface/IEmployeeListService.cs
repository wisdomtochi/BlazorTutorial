using EmployeeMangement.Models.Employee.EmployeeList;

namespace BlazorWebApp.Services.Interface
{
    public interface IEmployeeListService
    {
        Task<EmployeeList> GetEmployees();
    }
}

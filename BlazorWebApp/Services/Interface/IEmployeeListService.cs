using EmployeeMangement.Models.Employee.EmployeeList;

namespace BlazorApp.Services.Interface
{
    public interface IEmployeeListService
    {
        Task<EmployeeList> GetEmployees();
    }
}

using EmployeeMangement.Models.Employee.EmployeeDetails;

namespace BlazorWebApp.Services.Interface
{
    public interface IEmployeeDetailsService
    {
        Task<GetEmployee> GetEmployee(Guid id);
    }
}

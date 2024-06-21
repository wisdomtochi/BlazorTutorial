using EmployeeMangement.Models.Employee.EmployeeDetails;

namespace BlazorApp.Services.Interface
{
    public interface IEmployeeDetailsService
    {
        Task<GetEmployee> GetEmployee(Guid id);
    }
}

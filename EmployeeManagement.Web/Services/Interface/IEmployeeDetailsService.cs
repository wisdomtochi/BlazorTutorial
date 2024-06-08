using EmployeeMangement.Models.Employee.EmployeeDetails;

namespace EmployeeManagement.Web.Services.Interface
{
    public interface IEmployeeDetailsService
    {
        Task<GetEmployee> GetEmployeeDetails(Guid id);
    }
}

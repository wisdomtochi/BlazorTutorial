using EmployeeMangement.Models.Employee;

namespace EmployeeManagement.Web.Services
{
    public interface IEmployeeService
    {
        Task<AllEmployees> GetEmployees();
    }
}

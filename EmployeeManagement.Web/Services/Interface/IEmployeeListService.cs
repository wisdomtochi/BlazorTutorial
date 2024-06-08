using EmployeeMangement.Models.Employee.EmployeeList;

namespace EmployeeManagement.Web.Services.Interface
{
    public interface IEmployeeListService
    {
        Task<EmployeeList> GetEmployees();
    }
}

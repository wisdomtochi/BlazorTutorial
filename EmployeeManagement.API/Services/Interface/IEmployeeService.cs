using EmployeeManagement.API.DTO.Read;
using EmployeeManagement.API.Helpers;

namespace EmployeeManagement.API.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Result<List<EmployeeDTO>>> GetAllEmployees();
        Task<Result<EmployeeDTO>> GetEmployee(Guid Id);
        Task<Result> CreateEmployee(EmployeeDTO employee);
    }
}

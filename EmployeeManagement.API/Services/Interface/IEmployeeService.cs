using EmployeeManagement.API.DTO.Write;
using EmployeeManagement.API.Helpers;

namespace EmployeeManagement.API.Services.Interface
{
    public interface IEmployeeService
    {
        Task<Result<List<EmployeeDTOw>>> GetAllEmployees();
        Task<Result<EmployeeDTOw>> GetEmployee(Guid Id);
    }
}

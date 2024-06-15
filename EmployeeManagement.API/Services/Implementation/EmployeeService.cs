using EmployeeManagement.API.DTO.Write;
using EmployeeManagement.API.Helpers;
using EmployeeManagement.API.Services.Interface;

namespace EmployeeManagement.API.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        public Task<Result<List<EmployeeDTOw>>> GetAllEmployees()
        {
            throw new NotImplementedException();
        }

        public Task<Result<EmployeeDTOw>> GetEmployee(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}

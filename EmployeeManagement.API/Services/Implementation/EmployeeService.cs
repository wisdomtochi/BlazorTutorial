using EmployeeManagement.API.DataAccess.Interface;
using EmployeeManagement.API.Domain;
using EmployeeManagement.API.DTO.Read;
using EmployeeManagement.API.Helpers;
using EmployeeManagement.API.Mapper;
using EmployeeManagement.API.Services.Interface;

namespace EmployeeManagement.API.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork<Employee> employeeUoW;

        public EmployeeService(IUnitOfWork<Employee> employeeUoW)
        {
            this.employeeUoW = employeeUoW;
        }
        public async Task<Result<List<EmployeeDTO>>> GetAllEmployees()
        {
            var employees = await employeeUoW.Repository.ReadAll();

            if (!employees.Any()) return Result.Failure<List<EmployeeDTO>>("No Employee Found.");

            var employeeList = Map.Employees(employees);

            return Result.Success(employeeList);
        }

        public async Task<Result<EmployeeDTO>> GetEmployee(Guid Id)
        {
            var employeeExist = await employeeUoW.Repository.ReadSingle(Id);

            if (employeeExist == null) return Result.Failure<EmployeeDTO>("Employee Not Found");

            var employee = Map.Employees(new List<Employee> { employeeExist }).FirstOrDefault();

            return Result.Success(employee);
        }

        public async Task<Result> CreateEmployee(EmployeeDTO employee)
        {
            var EmployeeExist = await employeeUoW.Repository.ReadSingle(employee.Id);

            if (EmployeeExist != null) return Result.Failure("Employee Already Exists.");

            Employee newEmployee = new()
            {
                Id = Guid.NewGuid(),
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                Gender = employee.Gender
            };

            await employeeUoW.Repository.Create(newEmployee);
            await employeeUoW.SaveAsync();
            return Result.Success("Employee Created Successfully.");
        }
    }
}

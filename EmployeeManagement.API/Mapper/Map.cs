using EmployeeManagement.API.Domain;
using EmployeeManagement.API.DTO.Write;

namespace EmployeeManagement.API.Mapper
{
    public class Map
    {
        public List<EmployeeDTOw> Employees(IEnumerable<Employee> source)
        {
            List<EmployeeDTOw> employees = source.Select(e => new EmployeeDTOw()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Gender = e.Gender,
                Department = e.Department
            }).ToList();

            return employees;
        }
    }
}

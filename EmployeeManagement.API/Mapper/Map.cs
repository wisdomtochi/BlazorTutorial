using EmployeeManagement.API.Domain;
using EmployeeManagement.API.DTO.Read;

namespace EmployeeManagement.API.Mapper
{
    public static class Map
    {
        public static List<EmployeeDTO> Employees(IEnumerable<Employee> source)
        {
            List<EmployeeDTO> employees = source.Select(e => new EmployeeDTO()
            {
                Id = e.Id,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Email = e.Email,
                Gender = e.Gender
            }).ToList();

            return employees;
        }
    }
}

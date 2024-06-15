using EmployeeManagement.API.Domain;
using EmployeeManagement.API.Helpers.Enums;

namespace EmployeeManagement.API.DTO.Write
{
    public class EmployeeDTOw
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }
}

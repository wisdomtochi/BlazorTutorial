using EmployeeManagement.API.Helpers.Enums;

namespace EmployeeManagement.API.Domain
{
    public class Employee
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public Department Department { get; set; }
    }

    public class Department
    {
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
    }
}

using EmployeeMangement.Models;
using Microsoft.AspNetCore.Components;

namespace EmployeeManagement.Web.Components.Pages
{
    public class EmployeesBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(CreateEmployees);
        }

        private void CreateEmployees()
        {
            System.Threading.Thread.Sleep(5000);

            Employee emp1 = new()
            {
                EmployeeId = 1,
                FirstName = "Chris",
                LastName = "John",
                DateOfBirth = new DateTime(1990, 02, 01),
                Department = new Department { DepartmentId = 2, DepartmentName = "Marketing" },
                Gender = Gender.Male,
                Email = "chrisjohn@gmail.com",
                PhotoPath = "images/chris.png"
            };

            Employee emp2 = new()
            {
                EmployeeId = 2,
                FirstName = "Mercy",
                LastName = "Rejoice",
                DateOfBirth = new DateTime(1998, 12, 11),
                Department = new Department { DepartmentId = 3, DepartmentName = "IT" },
                Gender = Gender.Female,
                Email = "mercy@gmail.com",
                PhotoPath = "images/mercy.jpg"
            };

            Employee emp3 = new()
            {
                EmployeeId = 3,
                FirstName = "Ruth",
                LastName = "Sandra",
                DateOfBirth = new DateTime(1995, 05, 21),
                Department = new Department { DepartmentId = 1, DepartmentName = "HR" },
                Gender = Gender.Female,
                Email = "ruth@gmail.com",
                PhotoPath = "images/ruth.jpeg"
            };

            Employees = [emp1, emp2, emp3];
        }
    }
}

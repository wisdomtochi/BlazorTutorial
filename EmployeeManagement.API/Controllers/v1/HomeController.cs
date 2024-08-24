using EmployeeManagement.API.DTO.Read;
using EmployeeManagement.API.Helpers;
using EmployeeManagement.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers.v1
{
    [Route("api/v1/[controller]/")]
    [ApiController]
    public class HomeController(IEmployeeService employeeService, ILogger<HomeController> logger) : ControllerBase
    {
        private readonly IEmployeeService employeeService = employeeService;
        private readonly ILogger<HomeController> logger = logger;

        [HttpGet]
        [Route("getemployee/{id}")]
        public async Task<IActionResult> GetEmployee([FromRoute] Guid id)
        {
            try
            {
                var result = await employeeService.GetEmployee(id);

                if (result.Succeeded) return Ok(new JsonMessage<EmployeeDTO>
                {
                    Status = true,
                    Result = result.Data
                });

                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = result.Message
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("allemployees")]
        //[Route]
        public async Task<IActionResult> AllEmployees()
        {
            try
            {
                var employees = await employeeService.GetAllEmployees();
                logger.LogInformation("Employees All Set.");
                if (employees.Succeeded) return Ok(new JsonMessage<EmployeeDTO>
                {
                    Status = true,
                    Results = employees.Data
                });

                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = employees.Message
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        [Route("addnewemployee")]
        public async Task<IActionResult> AddNewEmployee([FromBody] EmployeeDTO employeeDTO)
        {
            try
            {
                var employee = await employeeService.CreateEmployee(employeeDTO);

                if (employee.Succeeded) return Ok(new JsonMessage<string>
                {
                    Status = true,
                    Message = employee.Message
                });

                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = employee.Message
                });
            }
            catch (Exception ex)
            {
                return Ok(new JsonMessage<string>
                {
                    Status = false,
                    Message = ex.Message
                });
            }
        }
    }
}

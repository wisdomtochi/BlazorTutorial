using EmployeeMangement.Models.Error;

namespace EmployeeManagement.Web.Services.Interface
{
    public interface IErrorService
    {
        ErrorModel SetErrorMessage(string message);
    }
}

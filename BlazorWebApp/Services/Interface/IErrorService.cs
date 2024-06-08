using EmployeeMangement.Models.Error;

namespace BlazorWebApp.Services.Interface
{
    public interface IErrorService
    {
        ErrorModel SetErrorMessage(string message);
    }
}

using EmployeeMangement.Models.Error;

namespace BlazorApp.Services.Interface
{
    public interface IErrorService
    {
        ErrorModel SetErrorMessage(string message);
    }
}

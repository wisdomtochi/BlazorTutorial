using BlazorApp.Services.Interface;
using EmployeeMangement.Models.Error;

namespace BlazorApp.Services.Implementation
{
    public class ErrorService : IErrorService
    {
        public ErrorModel SetErrorMessage(string message)
        {
            ErrorModel error = new()
            {
                errorMessage = message
            };

            return error;
        }
    }
}

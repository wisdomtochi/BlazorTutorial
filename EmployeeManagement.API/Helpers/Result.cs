namespace EmployeeManagement.API.Helpers
{
    public record Result
    {
        protected Result(bool status, string message)
        {
            this.Message = message;
            this.Succeeded = status;
        }

        private string Message;
        private bool Succeeded;

        public static Result Success(string message = null) => new(true, message);
        public static Result<T> Success<T>(T Data, string message = null) => new(Data, true, message);
        public static Result Failure(string message = null) => new(false, message);
        public static Result<T> Failure<T>(T Data, string message = null) => new(default(T), false, message);
    }

    public record Result<T> : Result
    {
        public Result(T Data, bool status, string message) : base(status, message)
        {
            this.Data = Data;
        }

        public T Data { get; set; }
    }
}

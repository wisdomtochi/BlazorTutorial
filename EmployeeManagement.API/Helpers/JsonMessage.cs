namespace EmployeeManagement.API.Helpers
{
    public class JsonMessage<T>
    {
        public T Result { get; set; }
        public List<T> Results { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }
    }
}

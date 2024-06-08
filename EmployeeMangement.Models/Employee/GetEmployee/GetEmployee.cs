namespace EmployeeMangement.Models.Employee.EmployeeDetails
{
    public class GetEmployee
    {
        public object results { get; set; }
        public Result result { get; set; }
        public bool status { get; set; }
        public object message { get; set; }
    }

    public class Result
    {
        public string id { get; set; }
        public string firstname { get; set; }
        public string lastName { get; set; }
        public int gender { get; set; }
        public int salary { get; set; }
    }
}

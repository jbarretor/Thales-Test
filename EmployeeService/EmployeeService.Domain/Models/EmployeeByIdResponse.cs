namespace EmployeeService.Domain.Models
{
    public class EmployeeByIdResponse
    {
        public string status { get; set; }
        public Employee data { get; set; }
        public string message { get; set; }
    }
}

namespace EmployeeService.Domain.Models
{
    public class EmployeesResponse
    {
        public string status { get; set; }
        public List<Employee> data { get; set; }
        public string message { get; set; }
    }
}

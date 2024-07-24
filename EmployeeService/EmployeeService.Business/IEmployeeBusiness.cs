using EmployeeService.Domain.Dtos;

namespace EmployeeService.Business
{
    public interface IEmployeeBusiness
    {
        public List<EmployeeDto> GetEmployeesAsync();

        public EmployeeDto GetEmployeeByIdAsync(int id);
    }
}
